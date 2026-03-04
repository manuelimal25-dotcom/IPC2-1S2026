namespace SistemaEstudiantes
{
    // Clase que representa un estudiante con sus datos básicos
    public class Estudiante
    {
        // Atributos privados
        private string nombre;
        private string carnet;
        private int[] notas;  // Array fijo de 3 notas
        private double promedio;

        // Constructor: recibe nombre, carnet y las 3 notas
        public Estudiante(string nombre, string carnet, int nota1, int nota2, int nota3)
        {
            this.nombre = nombre;
            this.carnet = carnet;
            
            // Array: almacenamos las 3 notas en un arreglo de tamaño fijo
            this.notas = new int[3];
            this.notas[0] = nota1;
            this.notas[1] = nota2;
            this.notas[2] = nota3;
            
            // Calculamos el promedio automáticamente
            this.promedio = CalcularPromedio();
        }

        // Método privado que calcula el promedio de las 3 notas
        private double CalcularPromedio()
        {
            int suma = 0;
            
            // Recorremos el array de notas
            for (int i = 0; i < notas.Length; i++)
            {
                suma += notas[i];
            }
            
            return suma / 3.0;  // Dividimos entre 3.0 para obtener decimal
        }

        // Tupla: método que retorna múltiples valores (promedio y estado)
        public (double promedio, string estado) ObtenerEstadoAcademico()
        {
            string estado;
            
            if (promedio >= 61)
                estado = "APROBADO";
            else
                estado = "REPROBADO";
            
            // Retornamos una tupla con dos valores
            return (promedio, estado);
        }

        // Getter: retorna el nombre del estudiante
        public string GetNombre()
        {
            return nombre;
        }

        // Setter: permite modificar el nombre (con validación)
        public void SetNombre(string nombre)
        {
            // Validación: no permitir nombres vacíos
            if (!string.IsNullOrWhiteSpace(nombre))
            {
                this.nombre = nombre;
            }
            else
            {
                throw new ArgumentException("El nombre no puede estar vacío.");
            }
        }
        public string GetCarnet()
        {
            return carnet;
        }
        public int[] GetNotas()
        {
            // Creamos una copia del array para proteger los datos internos
            int[] copiaNotas = new int[notas.Length];
            // Array.Copy (origen, destino, longitud)
            Array.Copy(notas, copiaNotas, notas.Length);
            return copiaNotas;
        }

        // Método para obtener una nota específica (más seguro que exponer el array)
        public int GetNota(int indice)
        {
            // Validación de índice
            if (indice >= 0 && indice < notas.Length)
            {
                return notas[indice];
            }
            else
            {
                throw new IndexOutOfRangeException("Índice de nota inválido. Debe ser 0, 1 o 2.");
            }
        }

        // Método para modificar una nota específica (con validación y recálculo)
        public void SetNota(int indice, int nuevaNota)
        {
            // Validación de índice
            if (indice < 0 || indice >= notas.Length)
            {
                throw new IndexOutOfRangeException("Índice de nota inválido. Debe ser 0, 1 o 2.");
            }

            // Validación de rango de nota
            if (nuevaNota < 0 || nuevaNota > 100)
            {
                throw new ArgumentException("La nota debe estar entre 0 y 100.");
            }

            // Modificamos la nota
            notas[indice] = nuevaNota;
            
            // Recalculamos el promedio automáticamente
            promedio = CalcularPromedio();
        }

        public double GetPromedio()
        {
            return promedio;
        }

        // Método para mostrar información del estudiante
        public void MostrarInfo()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Nombre: {nombre}");
            Console.WriteLine($"Carnet: {carnet}");
            Console.WriteLine($"Notas: {notas[0]}, {notas[1]}, {notas[2]}");
            Console.WriteLine($"Promedio: {promedio:F2}");
            var (prom, estado) = ObtenerEstadoAcademico();
            Console.WriteLine($"Estado: {estado}, Con promedio de: {prom}");
        }
    }
}