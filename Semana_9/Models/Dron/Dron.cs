namespace Semana_8.Models
{
    // Representa un dron individual con su nombre
    public class Dron
    {
        private string nombre;

        public Dron(string nombre)
        {
            this.nombre = nombre;
        }

        public string GetNombre()
        {
            return nombre;
        }

        public void SetNombre(string nombre)
        {
            this.nombre = nombre;
        }
    }
}