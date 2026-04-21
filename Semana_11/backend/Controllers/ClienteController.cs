using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    // Controlador que recibe las peticiones HTTP relacionadas con clientes
    // Su única responsabilidad es recibir la petición, llamar al servicio y devolver una respuesta
    [ApiController]
    // La ruta será api/cliente (toma el nombre del controlador automáticamente)
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        // El servicio contiene toda la lógica de negocio, el controlador no sabe cómo se guardan los datos
        private readonly ClienteServicio Servicio;

        // .NET se encarga de crear el servicio y usarlo en el controlador cuando llega una petición
        public ClienteController(ClienteServicio servicio)
        {
            Servicio = servicio;
        }

        [HttpGet]
        public IActionResult ObtenerTodos()
        {
            List<Cliente> clientes = Servicio.ObtenerTodos();
            return Ok(clientes);
        }

        [HttpGet("{nit}")]
        public IActionResult ObtenerPorNit(string nit)
        {
            Cliente? cliente = Servicio.ObtenerPorNit(nit);

            if (cliente == null)
            {
                return NotFound($"Cliente con NIT {nit} no encontrado.");
            }

            return Ok(cliente);
        }

        // Recibe una lista de clientes en el cuerpo de la petición y los guarda usando el servicio
        [HttpPost]
        public IActionResult GuardarClientes([FromBody] List<Cliente> clientes)
        {
            var (creados, actualizados) = Servicio.GuardarClientes(clientes);

            return Ok(new
            {
                creados,
                actualizados
            });
        }
    }
}