namespace Semana_7
{
    public class Libro
    {
        private string titulo;
        private string autor;

        public Libro(string titulo, string autor)
        {
            this.titulo = titulo;
            this.autor = autor;
        }

        public string GetTitulo()
        {
            return titulo;
        }

        public string GetAutor()
        {
            return autor;
        }
        // Override indica que se va a modificar el comportamiento del método ToString() heredado de la clase Object
        public override string ToString()
        {
            return $"{titulo} - {autor}";
        }
    }
}