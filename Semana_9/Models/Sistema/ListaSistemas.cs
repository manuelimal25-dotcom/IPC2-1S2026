using System.Text;

namespace Semana_8.Models
{
    // Lista doblemente enlazada de sistemas de drones
    public class ListaSistemas
    {
        private NodoSistema? cabeza;
        private NodoSistema? cola;

        public ListaSistemas()
        {
            cabeza = null;
            cola = null;
        }

        public NodoSistema? GetCabeza()
        {
            return cabeza;
        }

        // Inserta un sistema al final de la lista
        public void InsertarSistema(Sistema nuevoSistema)
        {
            NodoSistema nuevoNodo = new NodoSistema(nuevoSistema);

            // Si la lista está vacía
            if (cabeza == null)
            {
                cabeza = nuevoNodo;
                cola = nuevoNodo;
            }
            else
            {
                // Insertar al final
                nuevoNodo.SetAnterior(cola);
                cola!.SetSiguiente(nuevoNodo);
                cola = nuevoNodo;
            }
        }

        public void InicializarLista()
        {
            cabeza = null;
            cola = null;
        }

        // Genera archivo DOT de Graphviz para visualizar sistemas
        public void GraficarSistemasDrones(string rutaSalida)
        {
            NodoSistema? actual = cabeza;

            while (actual != null)
            {
                Sistema sistema = actual.GetDato();
                string nombreArchivo = Path.Combine(rutaSalida, $"{sistema.GetNombreSistema()}.dot");

                StringBuilder dot = new StringBuilder();
                dot.AppendLine("digraph G {");
                dot.AppendLine("    bgcolor=\"#0000FF44:#FF000044\" gradientangle=90");
                dot.AppendLine($"    label=\"{sistema.GetNombreSistema()}\"");
                dot.AppendLine("    node [shape=plaintext]");
                dot.AppendLine("    tabla [label=<");
                dot.AppendLine("    <TABLE BORDER=\"1\" CELLBORDER=\"1\" CELLSPACING=\"0\" CELLPADDING=\"10\">");
                
                // Fila de encabezado
                dot.Append("        <TR><TD BGCOLOR=\"#085879\"><FONT COLOR=\"white\">Altura</FONT></TD>");
                for (int i = 1; i <= sistema.GetAlturaMaxima(); i++)
                {
                    dot.Append($"<TD BGCOLOR=\"#65BABF\">{i}</TD>");
                }
                dot.AppendLine("</TR>");

                // Agrupar contenidos por dron
                var contenidosPorDron = new Dictionary<string, List<Contenido>>();
                NodoContenido? nodoContenido = sistema.GetListaContenido().GetCabeza();
                
                while (nodoContenido != null)
                {
                    Contenido cont = nodoContenido.GetDato();
                    if (!contenidosPorDron.ContainsKey(cont.GetNombreDron()))
                    {
                        contenidosPorDron[cont.GetNombreDron()] = new List<Contenido>();
                    }
                    contenidosPorDron[cont.GetNombreDron()].Add(cont);
                    nodoContenido = nodoContenido.GetSiguiente();
                }

                // Generar filas por dron
                foreach (var dron in contenidosPorDron)
                {
                    dot.Append($"        <TR><TD BGCOLOR=\"#C81D25\"><FONT COLOR=\"white\">{dron.Key}</FONT></TD>");
                    
                    // Ordenar contenidos por altura
                    var contenidosOrdenados = dron.Value.OrderBy(c => c.GetAltura()).ToList();
                    
                    for (int altura = 1; altura <= sistema.GetAlturaMaxima(); altura++)
                    {
                        var contenido = contenidosOrdenados.FirstOrDefault(c => c.GetAltura() == altura);
                        string letra = contenido != null ? contenido.GetLetra() : "";
                        dot.Append($"<TD BGCOLOR=\"#F45059\">{letra}</TD>");
                    }
                    
                    dot.AppendLine("</TR>");
                }

                dot.AppendLine("    </TABLE>>];");
                dot.AppendLine("}");

                // Escribir archivo DOT
                File.WriteAllText(nombreArchivo, dot.ToString());
                Console.WriteLine($"Archivo DOT generado: {nombreArchivo}");

                actual = actual.GetSiguiente();
            }
        }
    }
}