using System.Text.Json.Serialization;

namespace backend.Models
{
    public class ResumenIngreso
    {
        [JsonPropertyName("banco")]
        public string Banco { get; set; } = string.Empty;

        [JsonPropertyName("mes")]
        public string Mes { get; set; } = string.Empty;

        [JsonPropertyName("total")]
        public decimal Total { get; set; }
    }
}