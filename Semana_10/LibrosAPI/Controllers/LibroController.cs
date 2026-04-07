using Microsoft.AspNetCore.Mvc;
using LibrosAPI.Modelo;
using LibrosAPI.Servicio;

namespace LibrosAPI.Controllers
{
    // ApiController: Indica que esta clase es un controlador de API.
    // Habilita características como la validación automática de modelos y respuestas formateadas.
    [ApiController]

    // Route: Define la ruta base para las acciones de este controlador.
    // "api/libros" significa que todas las rutas de este controlador comenzarán con "api/libros".
    [Route("api/libros")]
    public class LibrosController : ControllerBase
    {
        // Inyección de dependencia del servicio de libros para acceder a la lógica de negocio.
        private readonly LibroServicio libroServicio;

        public LibrosController(LibroServicio libroServicio)
        {
            this.libroServicio = libroServicio;
        }

        // GET api/libros
        [HttpGet]
        public ActionResult<List<Libro>> ObtenerTodos()
        {
            return Ok(libroServicio.ObtenerTodos());
        }

        // GET api/libros/{id}
        [HttpGet("{id}")]
        public ActionResult<Libro> ObtenerPorId(string id)
        {
            Libro? libro = libroServicio.ObtenerPorId(id);

            if (libro == null)
                return NotFound(new { mensaje = $"No se encontró ningún libro con el Id: {id}" });

            return Ok(libro);
        }

        // POST api/libros
        [HttpPost]
        public ActionResult<Libro> Agregar([FromBody] Libro libro)
        {
            Libro libroCreado = libroServicio.Agregar(libro);
            return Created($"api/libros/{libroCreado.Id}", libroCreado);
        }

        // PUT api/libros/{id}
        [HttpPut("{id}")]
        public ActionResult Actualizar(string id, [FromBody] Libro libroActualizado)
        {
            bool actualizado = libroServicio.Actualizar(id, libroActualizado);

            if (!actualizado)
                return NotFound( new { mensaje = $"No se encontró ningún libro con el Id: {id}" });

            return NoContent();
        }

        // DELETE api/libros/{id}
        [HttpDelete("{id}")]
        public ActionResult Eliminar(string id)
        {
            bool eliminado = libroServicio.Eliminar(id);

            if (!eliminado)
                return NotFound(new { mensaje = $"No se encontró ningún libro con el Id: {id}" });

            return NoContent();
        }
    }
}