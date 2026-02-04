using Semana_2.Modelos;

namespace Semana_2.Modelos
{
    // CLASE: SensorSuelo.
    // HERENCIA: Hereda de la clase Sensor.
    public class SensorSuelo : Sensor
    {
        // ATRIBUTO: Específico de sensores de suelo.
        private string tipoMedicion;

        // MÉTODO: Constructor.
        // Llama al constructor de la clase padre con 'base'.
        public SensorSuelo(string id, string nombre, string tipoMedicion, EstacionBase estacion) 
            : base(id, nombre, estacion)
        {
            this.tipoMedicion = tipoMedicion;
        }

        // MÉTODO: Getter
        public string GetTipoMedicion()
        {
            return tipoMedicion;
        }

        // MÉTODO: Implementación del método abstracto de la clase padre.
        // POLIMORFISMO: Versión específica para sensores de suelo.
        public override void MostrarInfo()
        {
            Console.WriteLine($"[SENSOR DE SUELO]");
            Console.WriteLine($"ID: {GetId()}");
            Console.WriteLine($"Nombre: {GetNombre()}");
            Console.WriteLine($"Tipo: {tipoMedicion}");
            Console.WriteLine($"Conectado a: {GetEstacion().GetNombre()}");
            

        }

        // MÉTODO: Implementación del método abstracto.
        // POLIMORFISMO: Comportamiento específico para medir suelo.
        public override void RealizarMedicion()
        {
            Console.WriteLine($"Midiendo {tipoMedicion} del suelo...");
        }
    }
}