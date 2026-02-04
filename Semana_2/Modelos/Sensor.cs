namespace Semana_2.Modelos
{
    // CLASE: Sensor (abstracta)
    // ABSTRACCIÓN: Define la estructura general de un sensor
    public abstract class Sensor
    {
        // ATRIBUTOS: Variables que guardan información del sensor.
        // ENCAPSULAMIENTO: Son privados, solo accesibles mediante métodos.
        private string id;
        private string nombre;
        private EstacionBase estacionConectada;

        // MÉTODO: Constructor
        public Sensor(string id, string nombre, EstacionBase estacion)
        {
            this.id = id;
            this.nombre = nombre;
            estacionConectada = estacion;
        }

        // MÉTODOS: Getters para acceder a atributos privados.
        // ENCAPSULAMIENTO: Controlan el acceso a los datos.
        public string GetId()
        {
            return id;
        }

        public string GetNombre()
        {
            return nombre;
        }

        public EstacionBase GetEstacion()
        {
            return estacionConectada;
        }
        // MÉTODOS ABSTRACTOS: Deben ser implementados por las clases hijas.
        // ABSTRACCIÓN: Define comportamientos que cada tipo de sensor debe tener.
        // POLIMORFISMO: Cada clase hija los implementará de forma diferente.
        public abstract void MostrarInfo();
        public abstract void RealizarMedicion();
    }
}