using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;
using System.Text.Json;

using LibroModelo = LibrosRazor.Modelo.Libro;

namespace LibrosRazor.Pages.Libro
{
    public class EditarModel : PageModel
    {
        private readonly IHttpClientFactory clienteFactory;

        [BindProperty]
        public LibroModelo LibroForm { get; set; } = new LibroModelo();

        public string MensajeError { get; set; } = string.Empty;

        public EditarModel(IHttpClientFactory clienteFactory)
        {
            this.clienteFactory = clienteFactory;
        }

        // Carga los datos actuales del libro para pre-llenar el formulario
        public async Task<IActionResult> OnGetAsync(string? id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                MensajeError = "El id del libro es invalido.";
                return RedirectToPage("/Index");
            }

            HttpClient cliente = clienteFactory.CreateClient("LibrosAPI");
            HttpResponseMessage respuesta = await cliente.GetAsync($"api/libros/{id}");

            if (!respuesta.IsSuccessStatusCode)
            {
                MensajeError = "No se encontro el libro solicitado.";
                return RedirectToPage("/Index");
            }

            string contenido = await respuesta.Content.ReadAsStringAsync();
            LibroForm = JsonSerializer.Deserialize<LibroModelo>(contenido, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }) ?? new LibroModelo();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            HttpClient cliente = clienteFactory.CreateClient("LibrosAPI");

            string contenido = JsonSerializer.Serialize(LibroForm);
            StringContent peticion = new StringContent(contenido, Encoding.UTF8, "application/json");

            HttpResponseMessage respuesta = await cliente.PutAsync($"api/libros/{LibroForm.Id}", peticion);

            if (respuesta.IsSuccessStatusCode)
                return RedirectToPage("/Index");

            // La API retornó un error, se notifica al usuario sin exponer detalles internos
            MensajeError = "Ocurrio un error al actualizar el libro.";
            return Page();
        }
    }
}