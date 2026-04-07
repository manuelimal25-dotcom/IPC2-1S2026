using System.Text.Json.Serialization;

namespace LibrosAPI.Modelo
{
    public class Libro
    {
        // La propiedad Id se genera automáticamente y no se puede cambiar desde afuera.
        // Por ésta razón el setter es privado.
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        // Inicializado con string.Empty para garantizar un estado no-nulo por defecto.
        [JsonPropertyName("titulo")]
        public string Titulo { get; set; } = string.Empty;

        [JsonPropertyName("autor")]
        public string Autor { get; set; } = string.Empty;

        [JsonPropertyName("precio")]
        public decimal Precio { get; set; }

        [JsonPropertyName("anio")]
        public int Anio { get; set; }

        // Constructor Principal
        public Libro(string titulo, string autor, decimal precio, int anio)
        {
            Id     = Guid.NewGuid().ToString();
            Titulo = titulo;
            Autor  = autor;
            Precio = precio;
            Anio   = anio;
        }

        // Constructor vacío requerido por el deserializador JSON
        public Libro()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}