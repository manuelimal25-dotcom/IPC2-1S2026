namespace Semana_2.Modelos
{
    // CLASE: EstacionBase
    public class EstacionBase
    {
        // ATRIBUTOS: Variables que guardan información de la estación.
        // ENCAPSULAMIENTO: Son privados.
        private string id;
        private string nombre;
        private bool activa;

        // MÉTODO: Constructor
        public EstacionBase(string id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
            activa = true;
        }

        // MÉTODOS: Getters.
        // ENCAPSULAMIENTO: Controlan el acceso a los atributos.
        public string GetId()
        {
            return id;
        }

        public string GetNombre()
        {
            return nombre;
        }

        public bool EstaActiva()
        {
            return activa;
        }
        // MÉTODOS: Para cambiar el estado de la estación.
        public void Activar()
        {
            activa = true;
            Console.WriteLine($"Estacion {nombre} activada.");
        }

        public void Desactivar()
        {
            activa = false;
            Console.WriteLine($"Estacion {nombre} desactivada.");
        }

        // MÉTODO: Para mostrar información
        public void MostrarInfo()
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine($"Estacion: {nombre} (ID: {id})");
            Console.WriteLine($"Estado: {(activa ? "Activa" : "Inactiva")}");
        }
    }
}