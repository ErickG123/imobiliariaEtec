using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ImobiliariaEtec.Data;
using ImobiliariaEtec.Models;

namespace ImobiliariaEtec.Controllers
{
    public class TipoEstabelecimentosController : Controller
    {
        private readonly ImobiliariaEtecContext _context;

        public TipoEstabelecimentosController(ImobiliariaEtecContext context)
        {
            _context = context;
        }

        // GET: TipoEstabelecimentos
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoEstabelecimentos.ToListAsync());
        }

        // GET: TipoEstabelecimentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoEstabelecimento = await _context.TipoEstabelecimentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoEstabelecimento == null)
            {
                return NotFound();
            }

            return View(tipoEstabelecimento);
        }

        // GET: TipoEstabelecimentos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoEstabelecimentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] TipoEstabelecimento tipoEstabelecimento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoEstabelecimento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoEstabelecimento);
        }

        // GET: TipoEstabelecimentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoEstabelecimento = await _context.TipoEstabelecimentos.FindAsync(id);
            if (tipoEstabelecimento == null)
            {
                return NotFound();
            }
            return View(tipoEstabelecimento);
        }

        // POST: TipoEstabelecimentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] TipoEstabelecimento tipoEstabelecimento)
        {
            if (id != tipoEstabelecimento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoEstabelecimento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoEstabelecimentoExists(tipoEstabelecimento.Id))
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
            return View(tipoEstabelecimento);
        }

        // GET: TipoEstabelecimentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoEstabelecimento = await _context.TipoEstabelecimentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoEstabelecimento == null)
            {
                return NotFound();
            }

            return View(tipoEstabelecimento);
        }

        // POST: TipoEstabelecimentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoEstabelecimento = await _context.TipoEstabelecimentos.FindAsync(id);
            _context.TipoEstabelecimentos.Remove(tipoEstabelecimento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoEstabelecimentoExists(int id)
        {
            return _context.TipoEstabelecimentos.Any(e => e.Id == id);
        }
    }
}
