using Microsoft.AspNetCore.Mvc;
using Semana_8.Models;

namespace Semana_8.Controllers
{
    public class HomeController : Controller
    {
        // Referencia a la lista global de drones del DronController
        private static ListaDrones listaDrones
        {
            get { return DronController.GetListaDrones(); }
        }

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

        // GET: /Home/CargarArchivo - Muestra el formulario para cargar el archivo XML
        public IActionResult CargarArchivo()
        {
            return View();
        }

        // POST: /Home/ProcesarArchivo - Recibe el archivo subido
        [HttpPost]
        public IActionResult ProcesarArchivo(IFormFile archivoXml)
        {
            if (archivoXml == null || archivoXml.Length == 0)
            {
                ViewBag.Mensaje = "No se seleccionó ningún archivo.";
                ViewBag.Tipo = "error";
                return View("CargarArchivo");
            }

            // Validar que sea un archivo XML
            if (!archivoXml.FileName.EndsWith(".xml", StringComparison.OrdinalIgnoreCase))
            {
                ViewBag.Mensaje = "El archivo debe ser de tipo XML (.xml)";
                ViewBag.Tipo = "error";
                return View("CargarArchivo");
            }

            try
            {
                // Guardar temporalmente el archivo en wwwroot/temp/
                string carpetaTemp = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "temp");
                
                // Crear carpeta si no existe
                if (!Directory.Exists(carpetaTemp))
                {
                    Directory.CreateDirectory(carpetaTemp);
                }

                string rutaArchivo = Path.Combine(carpetaTemp, archivoXml.FileName);

                // Guardar el archivo
                using (var stream = new FileStream(rutaArchivo, FileMode.Create))
                {
                    archivoXml.CopyTo(stream);
                }

                // Leer el archivo XML y cargar los drones
                LeerXML.LeerArchivoXML(rutaArchivo, listaDrones);

                // Eliminar el archivo temporal
                if (System.IO.File.Exists(rutaArchivo))
                {
                    System.IO.File.Delete(rutaArchivo);
                }

                ViewBag.Mensaje = "Archivo XML cargado correctamente.";
                ViewBag.Tipo = "exito";
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = $"Error al procesar el archivo: {ex.Message}";
                ViewBag.Tipo = "error";
            }

            return View("CargarArchivo");
        }

        // GET: /Home/GenerarArchivo
        public IActionResult GenerarArchivo()
        {
            return View("Index");
        }

        // GET: /Home/Inicializar
        public IActionResult Inicializar()
        {
            // Limpiar la lista de drones
            listaDrones.InicializarLista();
            ViewBag.Mensaje = "Sistema inicializado correctamente.";
            return View("Index");
        }
    }
}