using Semana_4.Lista_Doble;
namespace Semana_4.Clases
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