using Semana_5.Lista_Doble;
using System.Text;
using Semana_5.Grafica;
namespace Semana_5.Clases
{
    public class Paciente
    {
        private string nombre;
        private string edad;
        private int periodos;
        private int matriz;

        private ListaDoble celdas;
        public Paciente(string nombre, string edad, int periodos, int matriz)
        {
            this.nombre = nombre;
            this.edad = edad;
            this.periodos = periodos;
            this.matriz = matriz;
            this.celdas = new ListaDoble();
        }
        public string GetNombre()
        {
            return nombre;
        }
        public void SetNombre(string nombre)
        {
            this.nombre = nombre;
        }
        public string GetEdad()
        {
            return edad;
        }

        public void SetEdad(string edad)
        {
            this.edad = edad;
        }

        public int GetPeriodos()
        {
            return periodos;
        }

        public void SetPeriodos(int periodos)
        {
            this.periodos = periodos;
        }

        public string DatosPacienteGraphviz(string nombreNodo)
        {
            // StringBuilder: Clase que facilita la construcción de cadenas de texto de manera eficiente
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"    {nombreNodo} [");
            sb.AppendLine($"        shape=record,");
            sb.AppendLine($"        style=\"filled,rounded\",");
            sb.AppendLine($"        fillcolor=\"lightblue:white\",");
            sb.AppendLine($"        gradientangle=90,");
            sb.AppendLine($"        color=\"#1976d2\",");
            sb.AppendLine($"        penwidth=2,");
            sb.AppendLine($"        label=\"{{");
            sb.AppendLine($"            <nombre> Nombre: {nombre} |");
            sb.AppendLine($"            <edad> Edad: {edad} |");
            sb.AppendLine($"            <periodos> Períodos: {periodos} |");
            sb.AppendLine($"            <matriz> Matriz: {matriz}x{matriz} ");
            sb.AppendLine($"        }}\"");
            sb.AppendLine($"    ];");
            // Devuelve el código Graphviz generado como una cadena
            return sb.ToString();
        }

        public void AgregarCelda(Celda celda)
        {
            this.celdas.Insertar(celda);
        }

        public void GraficarMatriz()
        {
            string rutaArchivoDot = $"matriz_{nombre}.dot";
            
            using (StreamWriter writer = new StreamWriter(rutaArchivoDot))
            {
                writer.WriteLine("digraph Matriz {");
                writer.WriteLine("    // Configuración general");
                writer.WriteLine("    bgcolor=\"#f5f5f5\";");
                writer.WriteLine($"    label=\"Paciente: {nombre}\\nMatriz {matriz}x{matriz}\";");
                writer.WriteLine("    labelloc=t;");
                writer.WriteLine("    fontsize=20;");
                writer.WriteLine("    fontcolor=\"#1565c0\";");
                writer.WriteLine("    fontname=\"Helvetica Bold\";");
                writer.WriteLine("    node [shape=square, width=0.6, height=0.6, fixedsize=true, fontsize=14, fontname=\"Courier Bold\"];");
                writer.WriteLine("    ranksep=0.3;");  // Separación vertical entre filas
                writer.WriteLine("    nodesep=0.3;");  // Separación horizontal entre columnas
                writer.WriteLine();
                
                // Crear cada celda de la matriz
                for (int fila = 1; fila <= matriz; fila++)
                {
                    for (int columna = 1; columna <= matriz; columna++)
                    {
                        Celda? celda = celdas.Buscar(fila, columna);
                        string nombreNodo = $"f{fila}_c{columna}";
                        
                        if (celda != null)
                        {
                            writer.WriteLine($"    {nombreNodo} [label=\"1\", style=filled, fillcolor=\"#ef5350\", fontcolor=\"white\"];");
                        }
                        else
                        {
                            writer.WriteLine($"    {nombreNodo} [label=\"0\", style=filled, fillcolor=\"#66bb6a\", fontcolor=\"white\"];");
                        }
                    }
                }
                
                writer.WriteLine();
                
                // Conexiones invisibles VERTICALES (mantener orden arriba-abajo)
                for (int fila = 1; fila <= matriz; fila++)
                {
                    writer.Write($"    {{ rank=same; ");
                    for (int columna = 1; columna <= matriz; columna++)
                    {
                        writer.Write($"f{fila}_c{columna}");
                        if (columna < matriz) writer.Write("; ");
                    }
                    writer.WriteLine(" }");
                }
                
                writer.WriteLine();
                
                // Conexiones invisibles HORIZONTALES (mantener orden izquierda-derecha)
                for (int fila = 1; fila <= matriz; fila++)
                {
                    for (int columna = 1; columna < matriz; columna++)
                    {
                        writer.WriteLine($"    f{fila}_c{columna} -> f{fila}_c{columna + 1} [style=invis, weight=10];");
                    }
                }
                
                writer.WriteLine();
                
                // Conexiones invisibles para mantener la estructura de la matriz 
                for (int columna = 1; columna <= matriz; columna++)
                {
                    for (int fila = 1; fila < matriz; fila++)
                    {
                        writer.WriteLine($"    f{fila}_c{columna} -> f{fila + 1}_c{columna} [style=invis, weight=10];");
                    }
                }
                
                writer.WriteLine("}");
            }
            
            Console.WriteLine($"Archivo DOT creado exitosamente en: {rutaArchivoDot}");
            
            GeneradorGrafica generador = new GeneradorGrafica();
            generador.GenerarGrafica(rutaArchivoDot);
        }
    }

}