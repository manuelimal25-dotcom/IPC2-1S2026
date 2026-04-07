using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

using LibroModelo = LibrosRazor.Modelo.Libro;

namespace LibrosRazor.Pages.Libro
{
    public class EliminarModel : PageModel
    {
        // Cliente HTTP para consultar y eliminar libros.
        private readonly IHttpClientFactory clienteFactory;

        [BindProperty]
        // Modelo enlazado para confirmar la eliminación.
        public LibroModelo Libro { get; set; } = new LibroModelo();

        // Mensaje de error para la vista.
        public string MensajeError { get; set; } = string.Empty;

        public EliminarModel(IHttpClientFactory clienteFactory)
        {
            this.clienteFactory = clienteFactory;
        }

        // Recupera el libro a eliminar.
        public async Task<IActionResult> OnGetAsync(string? id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return RedirectToPage("/Index");

            HttpClient cliente = clienteFactory.CreateClient("LibrosAPI");
            HttpResponseMessage respuesta = await cliente.GetAsync($"api/libros/{id}");

            if (!respuesta.IsSuccessStatusCode)
            {
                MensajeError = "No se encontro el libro solicitado.";
                return Page();
            }

            string contenido = await respuesta.Content.ReadAsStringAsync();
            Libro = JsonSerializer.Deserialize<LibroModelo>(contenido, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }) ?? new LibroModelo();

            return Page();
        }

        // Ejecuta la eliminación en la API.
        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrWhiteSpace(Libro.Id))
            {
                MensajeError = "El id del libro es invalido.";
                return Page();
            }

            HttpClient cliente = clienteFactory.CreateClient("LibrosAPI");
            HttpResponseMessage respuesta = await cliente.DeleteAsync($"api/libros/{Libro.Id}");

            if (respuesta.IsSuccessStatusCode)
                return RedirectToPage("/Index");

            MensajeError = "Ocurrio un error al eliminar el libro.";
            return Page();
        }
    }
}