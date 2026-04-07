using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using LibrosRazor.Modelo;

using LibroModelo = LibrosRazor.Modelo.Libro;

namespace LibrosRazor.Pages.Libros
{
    public class IndexModel : PageModel
    {
        private readonly IHttpClientFactory clienteFactory;

        public List<LibroModelo> Libros { get; set; } = new List<LibroModelo>();

        public IndexModel(IHttpClientFactory clienteFactory)
        {
            this.clienteFactory = clienteFactory;
        }

        public async Task OnGetAsync()
        {
            HttpClient cliente = clienteFactory.CreateClient("LibrosAPI");
            HttpResponseMessage respuesta = await cliente.GetAsync("api/libros");

            if (respuesta.IsSuccessStatusCode)
            {
                string contenido = await respuesta.Content.ReadAsStringAsync();
                Libros = JsonSerializer.Deserialize<List<LibroModelo>>(contenido, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }) ?? new List<LibroModelo>();
            }
        }
    }
}