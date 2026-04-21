using System.Text.Json.Serialization;

namespace backend.Models
{
    public class Banco
    {
        [JsonPropertyName("codigo")]
        public int Codigo { get; set; } 

        [JsonPropertyName("nombre")]
        public string Nombre { get; set; } = string.Empty;
    }
}