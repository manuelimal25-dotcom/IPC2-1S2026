using System.Text.Json.Serialization;

namespace backend.Models
{
    public class Pago
    {
        [JsonPropertyName("idPago")]
        public string Id_Pago { get; set; } = string.Empty;

        [JsonPropertyName("codigoBanco")]
        public int CodigoBanco { get; set; }

        [JsonPropertyName("fecha")]
        public string Fecha { get; set; } = string.Empty;

        [JsonPropertyName("nit")]
        public string NIT { get; set; } = string.Empty;

        [JsonPropertyName("valor")]
        public decimal Valor { get; set; }
    }
}