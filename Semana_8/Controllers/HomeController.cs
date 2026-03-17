using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Semana_8.Models;

namespace Semana_8.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/Index (Página principal)
        public IActionResult Index()
        {
            return View();
        }

        // GET: /Home/Ayuda
        public IActionResult Ayuda()
        {
            return View();
        }

        // GET: /Home/CargarArchivo
        public IActionResult CargarArchivo()
        {
            return View("Index");
        }

        // GET: /Home/GenerarArchivo
        public IActionResult GenerarArchivo()
        {
            return View("Index");
        }

        // GET: /Home/Inicializar
        public IActionResult Inicializar()
        {
            return View("Index");
        }
    }
}