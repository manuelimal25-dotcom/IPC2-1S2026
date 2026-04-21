using System.Text.Json.Serialization;

namespace backend.Models
{
    public class Factura
    {
        [JsonPropertyName("noFactura")]
        public string No_Factura { get; set; } = string.Empty;

        [JsonPropertyName("nit")]
        public string NIT { get; set; } = string.Empty;

        [JsonPropertyName("fecha")]
        public string Fecha { get; set; } = string.Empty;

        [JsonPropertyName("valor")]
        public decimal Valor { get; set; }
    }
}