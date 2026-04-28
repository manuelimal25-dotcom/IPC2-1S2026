using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using frontend.Models;

namespace frontend.Pages.Ingresos;

public class IndexModel : PageModel
{
    private readonly IHttpClientFactory HttpClient;

    public List<ResumenIngreso> Ingresos { get; set; } = new List<ResumenIngreso>();
    public bool Consultado { get; set; } = false;
    public int MesSeleccionado { get; set; }
    public int AnioSeleccionado { get; set; }

    public IndexModel(IHttpClientFactory httpClientFactory)
    {
        HttpClient = httpClientFactory;
    }

    public void OnGet() { }

    public async Task<IActionResult> OnPostAsync(int mes, int anio)
    {
        MesSeleccionado = mes;
        AnioSeleccionado = anio;

        HttpClient http = HttpClient.CreateClient("backend");
        HttpResponseMessage respuesta = await http.GetAsync($"/api/ingresos/{anio}/{mes}");

        string body = await respuesta.Content.ReadAsStringAsync();

        Ingresos = JsonSerializer.Deserialize<List<ResumenIngreso>>(body, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        }) ?? new List<ResumenIngreso>();

        Consultado = true;
        return Page();
    }
}