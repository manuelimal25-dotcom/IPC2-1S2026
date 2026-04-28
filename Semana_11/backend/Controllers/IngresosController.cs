using backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngresosController : ControllerBase
    {
        [HttpGet("{anio}/{mes}")]
        public IActionResult ObtenerIngresos(int anio, int mes)
        {
            // Datos Simulados 
            // Para el proyecto deben consultarse desde XmlDatabase
            List<ResumenIngreso> ingresos = new List<ResumenIngreso>
            {
                new ResumenIngreso { Banco = "BI",       Mes = "mar-24", Total = 4200 },
                new ResumenIngreso { Banco = "GyT",      Mes = "mar-24", Total = 4400 },
                new ResumenIngreso { Banco = "BanRural", Mes = "mar-24", Total = 3400 },
                new ResumenIngreso { Banco = "BAM",      Mes = "mar-24", Total = 4600 },

                new ResumenIngreso { Banco = "BI",       Mes = "feb-24", Total = 2300 },
                new ResumenIngreso { Banco = "GyT",      Mes = "feb-24", Total = 2100 },
                new ResumenIngreso { Banco = "BanRural", Mes = "feb-24", Total = 1800 },
                new ResumenIngreso { Banco = "BAM",      Mes = "feb-24", Total = 2800 },

                new ResumenIngreso { Banco = "BI",       Mes = "ene-24", Total = 2000 },
                new ResumenIngreso { Banco = "GyT",      Mes = "ene-24", Total = 2000 },
                new ResumenIngreso { Banco = "BanRural", Mes = "ene-24", Total = 3000 },
                new ResumenIngreso { Banco = "BAM",      Mes = "ene-24", Total = 5000 },
            };

            return Ok(ingresos);
        }
    }
}