using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;
using System.Text.Json;
using System.Xml;
using frontend.Models;

namespace frontend.Pages.LecturaXml;

public class ConfiguracionModel : PageModel
{
    private readonly IHttpClientFactory HttpClient;

    public int ClientesCreados { get; set; }
    public int ClientesActualizados { get; set; }
    public int BancosCreados { get; set; }
    public int BancosActualizados { get; set; }
    public bool Procesado { get; set; } = false;

    // .NET se encarga de crear el HttpClientFactory y dárselo a la página cuando llega una petición
    public ConfiguracionModel(IHttpClientFactory httpClientFactory)
    {
        HttpClient = httpClientFactory;
    }

    public void OnGet() { }

    public async Task<IActionResult> OnPostAsync(IFormFile archivo)
    {
        if (archivo == null || archivo.Length == 0)
            return Page();

        // Leer el archivo XML 
        XmlDocument xmlDoc = new XmlDocument();
        using (Stream stream = archivo.OpenReadStream())
        {
            xmlDoc.Load(stream);
        }

        // Extraer clientes del XML
        List<Cliente> clientes = new List<Cliente>();
        XmlNodeList nodoClientes = xmlDoc.GetElementsByTagName("cliente");
        foreach (XmlNode nodo in nodoClientes)
        {
            clientes.Add(new Cliente
            {
                NIT = nodo["NIT"]?.InnerText.Trim() ?? string.Empty,
                Nombre = nodo["nombre"]?.InnerText.Trim() ?? string.Empty,
                Saldo = 0
            });
        }

        // Extraer bancos del XML
        List<Banco> bancos = new List<Banco>();
        XmlNodeList nodoBancos = xmlDoc.GetElementsByTagName("banco");
        foreach (XmlNode nodo in nodoBancos)
        {
            bancos.Add(new Banco
            {
                Codigo = int.Parse(nodo["codigo"]?.InnerText.Trim() ?? "0"),
                Nombre = nodo["nombre"]?.InnerText.Trim() ?? string.Empty
            });
        }

        // Crear el cliente HTTP apuntando al backend
        HttpClient http = HttpClient.CreateClient("backend");

        // Enviar clientes al backend
        string jsonClientes = JsonSerializer.Serialize(clientes);
        StringContent contentClientes = new StringContent(jsonClientes, Encoding.UTF8, "application/json");
        HttpResponseMessage respuestaClientes = await http.PostAsync("/api/cliente", contentClientes);

        // Enviar bancos al backend
        string jsonBancos = JsonSerializer.Serialize(bancos);
        StringContent contentBancos = new StringContent(jsonBancos, Encoding.UTF8, "application/json");
        HttpResponseMessage respuestaBancos = await http.PostAsync("/api/banco", contentBancos);

        // Leer y deserializar respuestas del backend
        string bodyClientes = await respuestaClientes.Content.ReadAsStringAsync();
        string bodyBancos = await respuestaBancos.Content.ReadAsStringAsync();

        JsonDocument jsonDocClientes = JsonDocument.Parse(bodyClientes);
        JsonDocument jsonDocBancos = JsonDocument.Parse(bodyBancos);

        ClientesCreados = jsonDocClientes.RootElement.GetProperty("creados").GetInt32();
        ClientesActualizados = jsonDocClientes.RootElement.GetProperty("actualizados").GetInt32();
        BancosCreados = jsonDocBancos.RootElement.GetProperty("creados").GetInt32();
        BancosActualizados = jsonDocBancos.RootElement.GetProperty("actualizados").GetInt32();

        Procesado = true;
        return Page();
    }
}