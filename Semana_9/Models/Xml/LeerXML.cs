using System.Xml;

namespace Semana_8.Models
{
    public static class LeerXML
    {
        public static void LeerArchivoXML(string path, ListaDrones listaDrones)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("El archivo XML no existe.");
                return;
            }

            try
            {
                XmlDocument docXml = new XmlDocument();
                docXml.Load(path);

                // Obtener el nodo raíz "config"
                XmlNode? config = docXml.DocumentElement;
                if (config == null)
                {
                    Console.WriteLine("El archivo XML está vacío o mal formado.");
                    return;
                }

                // Buscar el nodo "listaDrones"
                XmlNode? listaDronesNode = config.SelectSingleNode("listaDrones");
                if (listaDronesNode == null)
                {
                    Console.WriteLine("No se encontró la lista de drones en el XML.");
                    return;
                }

                Console.WriteLine($"Procesando {listaDronesNode.ChildNodes.Count} drones del archivo XML.");

                // Procesar cada dron
                foreach (XmlNode nodoDron in listaDronesNode.ChildNodes)
                {
                    if (nodoDron.Name == "dron")
                    {
                        string? nombreDron = nodoDron.InnerText;
                        
                        if (!string.IsNullOrWhiteSpace(nombreDron))
                        {
                            Dron nuevoDron = new Dron(nombreDron);
                            listaDrones.InsertarDron(nuevoDron);
                            Console.WriteLine($"Dron '{nombreDron}' agregado a la lista.");
                        }
                    }
                }

                Console.WriteLine("Lectura del archivo XML completada.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al leer el archivo XML: {ex.Message}");
            }
        }
    }
}