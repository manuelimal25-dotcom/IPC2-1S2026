using Microsoft.AspNetCore.Mvc;
using Semana_8.Grafica;
using Semana_8.Models;

namespace Semana_8.Controllers
{
    public class SistemaController : Controller
    {
        // Lista estática para mantener los sistemas entre peticiones
        private static ListaSistemas listaSistemas = new ListaSistemas();

        // Método estático para acceder a la lista desde otros controladores
        public static ListaSistemas GetListaSistemas()
        {
            return listaSistemas;
        }

        // GET: /Sistema/Index
        public IActionResult Index()
        {
            if (listaSistemas.GetCabeza() != null)
            {
                string carpetaImagenes = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "sistemas");

                if (!Directory.Exists(carpetaImagenes))
                {
                    Directory.CreateDirectory(carpetaImagenes);
                }

                listaSistemas.GraficarSistemasDrones(carpetaImagenes);

                GeneradorGrafica generador = new GeneradorGrafica();
                NodoSistema? actual = listaSistemas.GetCabeza();

                while (actual != null)
                {
                    string nombreSistema = actual.GetDato().GetNombreSistema();
                    string rutaDot = Path.Combine(carpetaImagenes, nombreSistema + ".dot");

                    generador.GenerarGrafica(rutaDot);
                    actual = actual.GetSiguiente();
                }
            }

            return View(listaSistemas);
        }
    }
}