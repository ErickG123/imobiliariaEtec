using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ImobiliariaEtec.Data;
using ImobiliariaEtec.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace ImobiliariaEtec.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class EstabelecimentosController : Controller
    {
        private readonly ImobiliariaEtecContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public EstabelecimentosController(ImobiliariaEtecContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            webHostEnvironment = hostEnvironment;
        }

        // GET: Estabelecimentos
        public async Task<IActionResult> Index()
        {
            var imobiliariaEtecContext = _context.Estabelecimentos.Include(e => e.Cidade).Include(e => e.TipoEstabelecimento);
            return View(await imobiliariaEtecContext.ToListAsync());
        }

        // GET: Estabelecimentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estabelecimento = await _context.Estabelecimentos
                .Include(e => e.Cidade)
                .Include(e => e.TipoEstabelecimento)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estabelecimento == null)
            {
                return NotFound();
            }
            ViewData["CaminhoFoto"] = webHostEnvironment.WebRootPath;
            return View(estabelecimento);
        }

        // GET: Estabelecimentos/Create
        public IActionResult Create()
        {
            ViewData["CidadeId"] = new SelectList(_context.Cidades, "Id", "NomeCompleto");
            ViewData["TipoEstabelecimentoId"] = new SelectList(_context.TipoEstabelecimentos, "Id", "Nome");
            return View();
        }

        // POST: Estabelecimentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao,Endereco,Bairro,Cep,NumQuartos,NumBanheiros,Valor,TipoEstabelecimentoId,CidadeId,Foto,Nome,Metragem")] Estabelecimento estabelecimento, IFormFile Foto)
        {
            if (ModelState.IsValid)
            { 
                if (Foto != null)
                {
                    string pasta = Path.Combine(webHostEnvironment.WebRootPath, "images\\estabelecimentos");
                    var nomeArquivo = Guid.NewGuid().ToString() + "_" + Foto.FileName;
                    string caminhoArquivo = Path.Combine(pasta, nomeArquivo);
                    using (var stream = new FileStream(caminhoArquivo, FileMode.Create))
                    {
                        await Foto.CopyToAsync(stream);
                    };
                    estabelecimento.Foto = "/images/estabelecimentos/" + nomeArquivo;
                }
                _context.Add(estabelecimento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CidadeId"] = new SelectList(_context.Cidades, "Id", "Nome", estabelecimento.CidadeId);
            ViewData["TipoEstabelecimentoId"] = new SelectList(_context.TipoEstabelecimentos, "Id", "Nome", estabelecimento.TipoEstabelecimentoId);
            return View(estabelecimento);
        }

        // GET: Estabelecimentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estabelecimento = await _context.Estabelecimentos.FindAsync(id);
            if (estabelecimento == null)
            {
                return NotFound();
            }
            ViewData["CidadeId"] = new SelectList(_context.Cidades, "Id", "Nome", estabelecimento.CidadeId);
            ViewData["TipoEstabelecimentoId"] = new SelectList(_context.TipoEstabelecimentos, "Id", "Nome", estabelecimento.TipoEstabelecimentoId);
            ViewData["CaminhoFoto"] = webHostEnvironment.WebRootPath;
            return View(estabelecimento);
        }

        // POST: Estabelecimentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao,Endereco,Bairro,Cep,NumQuartos,NumBanheiros,Valor,TipoEstabelecimentoId,CidadeId,Foto,Nome,Metragem")] Estabelecimento estabelecimento, IFormFile NovaFoto)
        {
            if (id != estabelecimento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (NovaFoto != null)
                    {
                        string pasta = Path.Combine(webHostEnvironment.WebRootPath, "images\\estabelecimentos");
                        var nomeArquivo = Guid.NewGuid().ToString() + "_" + NovaFoto.FileName;
                        string caminhoArquivo = Path.Combine(pasta, nomeArquivo);
                        using (var stream = new FileStream(caminhoArquivo, FileMode.Create))
                        {
                            await NovaFoto.CopyToAsync(stream);
                        };
                        estabelecimento.Foto = "/images/estabelecimentos/" + nomeArquivo;
                    }
                    _context.Update(estabelecimento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstabelecimentoExists(estabelecimento.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CidadeId"] = new SelectList(_context.Cidades, "Id", "Nome", estabelecimento.CidadeId);
            ViewData["TipoEstabelecimentoId"] = new SelectList(_context.TipoEstabelecimentos, "Id", "Nome", estabelecimento.TipoEstabelecimentoId);
            ViewData["CaminhoFoto"] = webHostEnvironment.WebRootPath;
            return View(estabelecimento);
        }

        // GET: Estabelecimentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estabelecimento = await _context.Estabelecimentos
                .Include(e => e.Cidade)
                .Include(e => e.TipoEstabelecimento)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estabelecimento == null)
            {
                return NotFound();
            }

            return View(estabelecimento);
        }

        // POST: Estabelecimentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estabelecimento = await _context.Estabelecimentos.FindAsync(id);
            _context.Estabelecimentos.Remove(estabelecimento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstabelecimentoExists(int id)
        {
            return _context.Estabelecimentos.Any(e => e.Id == id);
        }
    }
}
