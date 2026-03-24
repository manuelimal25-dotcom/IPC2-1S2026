using System.Xml;

namespace Semana_8.Models
{
    public static class LeerXML
    {
        public static void LeerArchivoXML(string path, ListaDrones listaDrones, ListaSistemas listaSistemas)
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

                XmlNode? raiz = docXml.DocumentElement;
                if (raiz == null)
                {
                    Console.WriteLine("El archivo XML está vacío o mal formado.");
                    return;
                }

                // Soporta XML con raíz <config> o raíz directa <listaDrones>
                XmlNode? listaDronesNode = raiz.Name == "listaDrones"
                    ? raiz
                    : raiz.SelectSingleNode("listaDrones");

                if (listaDronesNode != null)
                {
                    foreach (XmlNode nodoDron in listaDronesNode.ChildNodes)
                    {
                        if (nodoDron.Name == "dron")
                        {
                            string nombreDron = nodoDron.InnerText.Trim();
                            if (!string.IsNullOrWhiteSpace(nombreDron) && !ExisteDron(listaDrones, nombreDron))
                            {
                                listaDrones.InsertarDron(new Dron(nombreDron));
                                Console.WriteLine($"Dron '{nombreDron}' agregado a la lista.");
                            }
                        }
                    }
                }

                // Soporta XML con raíz <config> o raíz directa <listaSistemasDrones>
                XmlNode? listaSistemasNode = raiz.Name == "listaSistemasDrones"
                    ? raiz
                    : raiz.SelectSingleNode("listaSistemasDrones");

                if (listaSistemasNode != null)
                {
                    foreach (XmlNode sistemaNode in listaSistemasNode.SelectNodes("sistemaDrones"))
                    {
                        string nombreSistema = sistemaNode.Attributes?["nombre"]?.Value?.Trim() ?? string.Empty;
                        if (string.IsNullOrWhiteSpace(nombreSistema))
                        {
                            continue;
                        }

                        int alturaMaxima = 0;
                        int.TryParse(sistemaNode.SelectSingleNode("alturaMaxima")?.InnerText?.Trim(), out alturaMaxima);

                        int cantidadDrones = 0;
                        int.TryParse(sistemaNode.SelectSingleNode("cantidadDrones")?.InnerText?.Trim(), out cantidadDrones);

                        ListaContenido listaContenido = new ListaContenido();

                        foreach (XmlNode contenidoNode in sistemaNode.SelectNodes("contenido"))
                        {
                            string nombreDron = contenidoNode.SelectSingleNode("dron")?.InnerText?.Trim() ?? string.Empty;
                            if (string.IsNullOrWhiteSpace(nombreDron))
                            {
                                continue;
                            }

                            if (!ExisteDron(listaDrones, nombreDron))
                            {
                                listaDrones.InsertarDron(new Dron(nombreDron));
                            }

                            foreach (XmlNode alturaNode in contenidoNode.SelectNodes("alturas/altura"))
                            {
                                int altura = 0;
                                int.TryParse(alturaNode.Attributes?["valor"]?.Value?.Trim(), out altura);
                                if (altura <= 0)
                                {
                                    continue;
                                }

                                string letra = alturaNode.InnerText;
                                letra = string.IsNullOrWhiteSpace(letra) ? string.Empty : letra.Trim();

                                listaContenido.InsertarContenido(new Contenido(nombreDron, altura, letra));
                            }
                        }

                        Sistema nuevoSistema = new Sistema(nombreSistema, alturaMaxima, cantidadDrones, listaContenido);
                        listaSistemas.InsertarSistema(nuevoSistema);
                        Console.WriteLine($"Sistema '{nombreSistema}' agregado con su contenido.");
                    }
                }

                Console.WriteLine("Lectura del archivo XML completada.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al leer el archivo XML: {ex.Message}");
            }
        }

        private static bool ExisteDron(ListaDrones listaDrones, string nombreDron)
        {
            NodoDron? actual = listaDrones.GetCabeza();
            while (actual != null)
            {
                if (string.Equals(actual.GetDato().GetNombre(), nombreDron, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }

                actual = actual.GetSiguiente();
            }

            return false;
        }
    }
}