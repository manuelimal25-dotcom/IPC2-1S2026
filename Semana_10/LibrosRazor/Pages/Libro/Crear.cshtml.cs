using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;
using System.Text.Json;
using LibrosRazor.Modelo;

using LibroModelo = LibrosRazor.Modelo.Libro;

namespace LibrosRazor.Pages.Libros
{
    public class CrearModel : PageModel
    {
        // Inyección de dependencia del cliente HTTP para realizar solicitudes a la API.
        private readonly IHttpClientFactory clienteFactory;
        // Propiedad para enlazar los datos del formulario de creación de libro.
        [BindProperty]
        public LibroModelo LibroForm { get; set; } = new LibroModelo();
        // Propiedad para almacenar mensajes de error en caso de que la creación falle.
        public string MensajeError { get; set; } = string.Empty;
        // Constructor que recibe el cliente HTTP a través de la inyección de dependencias.
        public CrearModel(IHttpClientFactory clienteFactory)
        {
            this.clienteFactory = clienteFactory;
        }
        // Se ejecuta cuando el usuario abre el formulario
        public void OnGet()
        {
        }
        // Se ejecuta cuando el usuario envía el formulario
        public async Task<IActionResult> OnPostAsync()
        {
            // Crear un cliente HTTP para comunicarse con la API de libros.
            HttpClient cliente = clienteFactory.CreateClient("LibrosAPI");
            // Serializar el objeto LibroForm a JSON para enviarlo en la solicitud POST.
            string contenido = JsonSerializer.Serialize(LibroForm);
            // Crear el contenido de la solicitud con el JSON serializado, especificando la codificación y el tipo de contenido.
            StringContent peticion = new StringContent(contenido, Encoding.UTF8, "application/json");
            // Enviar la solicitud POST a la API para agregar un nuevo libro.
            HttpResponseMessage respuesta = await cliente.PostAsync("api/libros", peticion);
            // Si la respuesta es exitosa, redirigir al usuario a la página de índice para ver la lista actualizada de libros.
            if (respuesta.IsSuccessStatusCode)
                return RedirectToPage("/Index");
            // Si la respuesta no es exitosa, establecer un mensaje de error para mostrar al usuario.
            MensajeError = "Ocurrio un error al agregar el libro.";
            return Page();
        }
    }
}