using Microsoft.AspNetCore.Mvc;

namespace Semana_8.Controllers
{
    public class MensajeController : Controller
    {
        // GET: /Mensaje/Index
        public IActionResult Index()
        {
            return View();
        }
    }
}