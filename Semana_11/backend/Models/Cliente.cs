using System.Text.Json.Serialization;

namespace backend.Models
{
    public class Cliente
    {
        [JsonPropertyName("nit")]
        public string NIT { get; set; } = string.Empty;

        [JsonPropertyName("nombre")]
        public string Nombre { get; set; } = string.Empty;

        [JsonPropertyName("saldo")]
        public decimal Saldo { get; set; }
    }
}