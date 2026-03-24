using Microsoft.AspNetCore.Mvc;
using Semana_8.Models;

namespace Semana_8.Controllers
{
    public class MensajeController : Controller
    {
        // Lista estática para mantener los mensajes entre peticiones
        private static ListaMensaje listaMensajes = new ListaMensaje();

        // Método estático para acceder a la lista desde otros controladores
        public static ListaMensaje GetListaMensajes()
        {
            return listaMensajes;
        }

        // GET: /Mensaje/Index
        public IActionResult Index()
        {
            return View(listaMensajes);
        }

        // POST: /Mensaje/MostrarLista
        [HttpPost]
        public IActionResult MostrarLista()
        {
            ViewBag.ListadoMensajes = listaMensajes.MostrarMensajes();
            // Después llamar al método, redirige a la vista Index para mostrar el resultado
            return View("Index", listaMensajes);
        }
    }
}