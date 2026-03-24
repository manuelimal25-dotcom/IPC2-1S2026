using Microsoft.AspNetCore.Mvc;
using Semana_8.Models;

namespace Semana_8.Controllers
{
    public class DronController : Controller
    {
        // Lista estática para mantener los drones entre peticiones
        private static ListaDrones listaDrones = new ListaDrones();

        // Método estático para acceder a la lista desde otros controladores
        public static ListaDrones GetListaDrones()
        {
            return listaDrones;
        }

        // GET: /Dron/Index
        public IActionResult Index()
        {
            return View(listaDrones);
        }

        // POST: /Dron/Agregar
        [HttpPost]
        public IActionResult Agregar(string nombreDron)
        {
            if (!string.IsNullOrWhiteSpace(nombreDron))
            {
                Dron nuevoDron = new Dron(nombreDron);
                listaDrones.InsertarDron(nuevoDron);
                Console.WriteLine($"Dron '{nombreDron}' agregado correctamente.");
            }

            return RedirectToAction("Index");
        }

        // POST: /Dron/MostrarLista
        [HttpPost]
        public IActionResult MostrarLista()
        {
            return View("Index", listaDrones);
        }
    }
}