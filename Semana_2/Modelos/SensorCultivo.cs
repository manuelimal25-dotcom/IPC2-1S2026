using Semana_2.Modelos;

namespace Semana_2.Modelos
{
    // CLASE: SensorCultivo.
    // HERENCIA: Hereda de la clase Sensor.
    public class SensorCultivo : Sensor
    {
        // ATRIBUTO: Específico de sensores de cultivo.
        private string indicador;

        // MÉTODO: Constructor.
        public SensorCultivo(string id, string nombre, string indicador, EstacionBase estacion) 
            : base(id, nombre, estacion)
        {
            this.indicador = indicador;
        }

        // MÉTODO: Getter
        public string GetIndicador()
        {
            return indicador;
        }

        // MÉTODO: Implementación del método abstracto.
        // POLIMORFISMO: Versión específica para sensores de cultivo.
        public override void MostrarInfo()
        {
            Console.WriteLine($"[SENSOR DE CULTIVO]");
            Console.WriteLine($"ID: {GetId()}");
            Console.WriteLine($"Nombre: {GetNombre()}");
            Console.WriteLine($"Indicador: {indicador}");
            Console.WriteLine($"Conectado a: {GetEstacion().GetNombre()}");
        }

        // MÉTODO: Implementación del método abstracto.
        // POLIMORFISMO: Comportamiento específico para medir cultivo.
        public override void RealizarMedicion()
        {
            Console.WriteLine($"Analizando {indicador} del cultivo...");
        }
    }
}