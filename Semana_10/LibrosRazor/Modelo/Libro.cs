namespace LibrosRazor.Modelo
{
    public class Libro
    {
        public string Id { get; set; } = string.Empty;
        public string Titulo { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int Anio { get; set; }
    }
}