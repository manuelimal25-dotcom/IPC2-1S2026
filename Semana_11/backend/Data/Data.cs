using System.Xml.Serialization;
using backend.Models;

namespace backend.Data
{
    [XmlRoot("BaseDeDatos")]
    public class BaseDeDatos
    {
        [XmlArray("Clientes")]
        [XmlArrayItem("Cliente")]
        public List<Cliente> Clientes { get; set; } = new List<Cliente>();

        [XmlArray("Bancos")]
        [XmlArrayItem("Banco")]
        public List<Banco> Bancos { get; set; } = new List<Banco>();

        [XmlArray("Facturas")]
        [XmlArrayItem("Factura")]
        public List<Factura> Facturas { get; set; } = new List<Factura>();

        [XmlArray("Pagos")]
        [XmlArrayItem("Pago")]
        public List<Pago> Pagos { get; set; } = new List<Pago>();
    }

    public class XmlDatabase
    {
        // Ruta del archivo XML donde se almacenará la base de datos
        private readonly string rutaArchivo;
        // Serializador XML para convertir objetos BaseDeDatos a XML y viceversa
        private readonly XmlSerializer serializador;

        public XmlDatabase()
        {
            // Inicializa la ruta del archivo XML y el serializador para la clase BaseDeDatos
            rutaArchivo = Path.Combine("Data", "BaseDeDatos.xml");
            serializador = new XmlSerializer(typeof(BaseDeDatos));
        }

        public BaseDeDatos Leer()
        {
            if (!File.Exists(rutaArchivo))
                return new BaseDeDatos();

            using FileStream stream = File.OpenRead(rutaArchivo);
            // Retorna un nuevo objeto BaseDeDatos deserializado desde el archivo XML
            return (BaseDeDatos)serializador.Deserialize(stream)!;
        }

        public void Guardar(BaseDeDatos baseDeDatos)
        {
            // Crea un nuevo archivo XML o sobrescribe el existente con el contenido de baseDeDatos serializado
            using FileStream stream = File.Create(rutaArchivo);
            serializador.Serialize(stream, baseDeDatos);
        }

        public void Limpiar()
        {
            Guardar(new BaseDeDatos());
        }
    }
}