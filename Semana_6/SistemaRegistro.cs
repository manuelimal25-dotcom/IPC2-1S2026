using System.Text.RegularExpressions;

namespace SistemaEstudiantes
{
    // Clase que gestiona el sistema de registro de estudiantes
    public class SistemaRegistro
    {
        // List: lista dinámica que puede crecer según sea necesario
        private List<Estudiante> listaEstudiantes;
        
        // Dictionary: permite búsqueda rápida por carnet (clave-valor)
        private Dictionary<string, Estudiante> diccionarioEstudiantes;

        // Constructor: inicializa las estructuras de datos
        public SistemaRegistro()
        {
            listaEstudiantes = new List<Estudiante>();
            diccionarioEstudiantes = new Dictionary<string, Estudiante>();
        }

        // Expresiones regulares: valida que el carnet tenga formato correcto (9 dígitos)
        public bool ValidarCarnet(string carnet)
        {
            // Patrón: debe ser exactamente 9 dígitos
            string patron = @"^\d{9}$";
            
            // Regex.IsMatch verifica si el carnet cumple con el patrón
            return Regex.IsMatch(carnet, patron);
        }

        // Método para agregar un estudiante al sistema
        public bool AgregarEstudiante(string nombre, string carnet, int nota1, int nota2, int nota3)
        {
            // Validamos el formato del carnet antes de agregar
            if (!ValidarCarnet(carnet))
            {
                Console.WriteLine("Error: El carnet debe tener 9 dígitos.");
                return false;
            }

            // Verificamos que el carnet no exista ya en el diccionario
            if (diccionarioEstudiantes.ContainsKey(carnet))
            {
                Console.WriteLine("Error: Ya existe un estudiante con ese carnet.");
                return false;
            }

            // Creamos el nuevo estudiante
            Estudiante nuevoEstudiante = new Estudiante(nombre, carnet, nota1, nota2, nota3);
            
            // List: agregamos a la lista dinámica
            listaEstudiantes.Add(nuevoEstudiante);
            
            // Dictionary: agregamos al diccionario (carnet como clave)
            diccionarioEstudiantes.Add(carnet, nuevoEstudiante);
            
            Console.WriteLine("Estudiante agregado exitosamente.");
            return true;
        }

        // Dictionary: buscar estudiante por carnet
        public Estudiante? BuscarPorCarnet(string carnet)
        {
            // TryGetValue es la forma segura de buscar en un diccionario
            // out Estudiante? estudiante es una variable de salida que contendrá el resultado si se encuentra
            if (diccionarioEstudiantes.TryGetValue(carnet, out Estudiante? estudiante))
            {
                return estudiante;
            }
            
            return null;  // No encontrado
        }

        // List: mostrar todos los estudiantes de la lista
        public void MostrarTodosLosEstudiantes()
        {
            if (listaEstudiantes.Count == 0)
            {
                Console.WriteLine("No hay estudiantes registrados.");
                return;
            }
            Console.WriteLine($"  TOTAL DE ESTUDIANTES: {listaEstudiantes.Count}");
            
            // Recorremos la lista
            foreach (Estudiante est in listaEstudiantes)
            {
                est.MostrarInfo();
            }
        }
    }
}