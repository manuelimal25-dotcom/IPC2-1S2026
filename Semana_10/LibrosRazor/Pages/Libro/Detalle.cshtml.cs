using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

using LibroModelo = LibrosRazor.Modelo.Libro;

namespace LibrosRazor.Pages.Libro
{
    public class DetalleModel : PageModel
    {
        // Cliente HTTP para consultar libros.
        private readonly IHttpClientFactory clienteFactory;

        // Libro mostrado en la vista.
        public LibroModelo Libro { get; set; } = new LibroModelo();

        // Mensaje de error para la vista.
        public string MensajeError { get; set; } = string.Empty;

        public DetalleModel(IHttpClientFactory clienteFactory)
        {
            this.clienteFactory = clienteFactory;
        }

        // Carga el libro por Id.
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
    }
}