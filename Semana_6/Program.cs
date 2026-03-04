using SistemaEstudiantes;

class Program
{
    static void Main(string[] args)
    {
        // Creamos el sistema de registro
        SistemaRegistro sistema = new SistemaRegistro();
        
        bool continuar = true;
        
        while (continuar)
        {
            MostrarMenu();
            string opcion = Console.ReadLine() ?? "0";
            
            switch (opcion)
            {
                case "1":
                    AgregarEstudiante(sistema);
                    break;
                case "2":
                    BuscarEstudiante(sistema);
                    break;
                case "3":
                    sistema.MostrarTodosLosEstudiantes();
                    break;
                case "0":
                    Console.WriteLine("¡Hasta pronto!");
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
            
            if (continuar)
            {
                Console.WriteLine("\nPresiona Enter para continuar...");
                Console.ReadLine();
            }
        }
    }

    // Muestra el menú principal
    static void MostrarMenu()
    {
        Console.Clear();
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("SISTEMA DE REGISTRO DE ESTUDIANTES");
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("1. Agregar estudiante");
        Console.WriteLine("2. Buscar estudiante por carnet");
        Console.WriteLine("3. Mostrar todos los estudiantes");
        Console.WriteLine("0. Salir");
        Console.WriteLine("----------------------------------------");
        Console.WriteLine();
        Console.Write("Seleccione una opción: ");
    }

    // Método para agregar un estudiante
    static void AgregarEstudiante(SistemaRegistro sistema)
    {
        Console.WriteLine("\n=== AGREGAR ESTUDIANTE ===");
        
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine() ?? "";
        
        Console.Write("Carnet (9 dígitos): ");
        string carnet = Console.ReadLine() ?? "";
        
        Console.Write("Nota 1 (0-100): ");
        int nota1 = int.Parse(Console.ReadLine() ?? "0");
        
        Console.Write("Nota 2 (0-100): ");
        int nota2 = int.Parse(Console.ReadLine() ?? "0");
        
        Console.Write("Nota 3 (0-100): ");
        int nota3 = int.Parse(Console.ReadLine() ?? "0");
        
        // Llamamos al método que valida y agrega
        sistema.AgregarEstudiante(nombre, carnet, nota1, nota2, nota3);
    }

    // Método para buscar un estudiante
    static void BuscarEstudiante(SistemaRegistro sistema)
    {
        Console.WriteLine("\n=== BUSCAR ESTUDIANTE ===");
        Console.Write("Ingrese el carnet: ");
        string carnet = Console.ReadLine() ?? "";
        
        // Dictionary: búsqueda rápida por carnet
        Estudiante? encontrado = sistema.BuscarPorCarnet(carnet);
        
        if (encontrado != null)
        {
            Console.WriteLine("\nEstudiante encontrado:");
            encontrado.MostrarInfo();
        }
        else
        {
            Console.WriteLine("No se encontró un estudiante con ese carnet.");
        }
    }
}