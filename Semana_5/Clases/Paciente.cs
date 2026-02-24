using Semana_5.Lista_Doble;
using System.Text;
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

        public void ImprimirDatosPaciente()
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine($"Nombre: {nombre}");
            Console.WriteLine($"Edad: {edad}");
            Console.WriteLine($"Periodos: {periodos}");
            Console.WriteLine($"Matriz: {matriz}");
        }

        // Genera el código Graphviz para un paciente
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
            sb.AppendLine($"            <matriz> Matriz: {matriz}x{matriz} |");
            sb.AppendLine($"        }}\"");
            sb.AppendLine($"    ];");
            // Devuelve el código Graphviz generado como una cadena
            return sb.ToString();
        }

        public void AgregarCelda(Celda celda)
        {
            this.celdas.Insertar(celda);
        }

        public void ImprimirCeldas()
        {
            Console.WriteLine("Recorrido Normal de Celdas Contagiadas:");
            celdas.Recorrer();
            Console.WriteLine("Recorrido Inverso de Celdas Contagiadas:");
            celdas.RecorrerInverso();
        }

        public void ImprimirMatriz()
        {
            Console.WriteLine($"-------------------");
            Console.WriteLine($"Matriz {matriz}x{matriz} - Paciente: {nombre}");
            Console.WriteLine();

            // Recorrer cada fila
            for (int fila = 1; fila <= matriz; fila++)
            {
                // Recorrer cada columna de la fila actual
                for (int columna = 1; columna <= matriz; columna++)
                {
                    // Buscar si existe esta celda en la lista de contagiadas
                    Celda? celda = celdas.Buscar(fila, columna);
                    
                    if (celda != null)
                    {
                        Console.Write("1 "); // Contagiada
                    }
                    else
                    {
                        Console.Write("0 "); // Sana
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine($"-------------------");
        }
    }

}