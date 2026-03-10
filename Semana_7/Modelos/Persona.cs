namespace Semana_7
{
    public class Persona
    {
        private string nombre;
        private int edad;

        public Persona(string nombre, int edad)
        {
            this.nombre = nombre;
            this.edad = edad;
        }

        public string GetNombre()
        {
            return nombre;
        }

        public int GetEdad()
        {
            return edad;
        }
        // Override indica que se va a modificar el comportamiento del método ToString() heredado de la clase Object
        public override string ToString()
        {
            return $"{nombre} ({edad} años)";
        }
    }
}