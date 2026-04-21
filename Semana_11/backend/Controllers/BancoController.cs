using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BancoController : ControllerBase
    {
        private readonly BancoServicio Servicio;

        public BancoController(BancoServicio servicio)
        {
            Servicio = servicio;
        }

        [HttpGet]
        public IActionResult ObtenerTodos()
        {
            List<Banco> bancos = Servicio.ObtenerTodos();
            return Ok(bancos);
        }

        [HttpGet("{codigo}")]
        public IActionResult ObtenerPorCodigo(int codigo)
        {
            Banco? banco = Servicio.ObtenerPorCodigo(codigo);

            if (banco == null)
                return NotFound($"Banco con código {codigo} no encontrado.");

            return Ok(banco);
        }

        [HttpPost]
        public IActionResult GuardarBancos([FromBody] List<Banco> bancos)
        {
            var (creados, actualizados) = Servicio.GuardarBancos(bancos);

            return Ok(new
            {
                creados,
                actualizados
            });
        }
    }
}