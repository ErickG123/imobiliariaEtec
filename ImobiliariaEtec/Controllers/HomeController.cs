using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ImobiliariaEtec.Models;
using ImobiliariaEtec.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace ImobiliariaEtec.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ImobiliariaEtecContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public HomeController(ILogger<HomeController> logger, ImobiliariaEtecContext context, IWebHostEnvironment hostEnvironment)
        {
            _logger = logger;
            _context = context;
            webHostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            var estabelecimentos = _context.Estabelecimentos
                  .Include(e => e.Cidade)
                  .Include(e => e.TipoEstabelecimento).ToList();
            ViewData["Caminho"] = webHostEnvironment.WebRootPath;
            return View(estabelecimentos);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
