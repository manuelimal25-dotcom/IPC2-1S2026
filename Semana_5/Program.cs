using System.Data;
using System.Diagnostics;
using Semana_5.Xml;
using Semana_5.Lista_Simple;
using Semana_5.Clases;

public static class Program
{
    public static void Main()
    {
        bool continuar = true;
        ListaSimple ListaPacientes = new ListaSimple();

        while (continuar)
        {
            MostrarMenu();
            string opcion = Console.ReadLine() ?? "";
            switch (opcion)
            {
                case "1":
                    LeerArchivo(ListaPacientes);
                    break;
                case "2":
                    EscribirArchivo();
                    break;
                case "3":
                    ListaPacientes.GraficarLista();
                    break;
                case "4":
                    GraficarMatrizPaciente(ListaPacientes);
                    break;
                case "0":
                    continuar = false;
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Por favor, ingrese una opción del menú.");
                    break;
            }
        }
    }

    // Muestra el menú principal de opciones
    public static void MostrarMenu()
    {
        Console.WriteLine("--------------------------------");
        Console.WriteLine("Menú Principal");
        Console.WriteLine("--------------------------------");
        Console.WriteLine("1. Leer Archivo XML");
        Console.WriteLine("2. Escribir Archivo XML");
        Console.WriteLine("3. Graficar Lista de Pacientes");
        Console.WriteLine("4. Graficar Matriz de un Paciente");
        Console.WriteLine("0. Salir");
        Console.WriteLine("--------------------------------");
        Console.Write("Opción: ");
    }

    public static void LeerArchivo(ListaSimple ListaPacientes)
    {
        string path = @"./Entrada2.xml";
        LeerXML.LeerArchivoXML(path, ListaPacientes);
    }
    
    // Llama a la función que escribe un archivo XML de salida
    public static void EscribirArchivo()
    {
        string path = @"./Salida.xml";
        EscribirXML.EscribirArchivoXML(path);
    }

    public static void GraficarMatrizPaciente(ListaSimple listaPacientes)
    {
        Console.Write("Ingrese el nombre del paciente para graficar su matriz: ");
        string nombrePaciente = Console.ReadLine() ?? "";
        
        Nodo? nodoPaciente = listaPacientes.BuscarPaciente(nombrePaciente);
        
        if (nodoPaciente != null)
        {
            Paciente paciente = nodoPaciente.GetDato();
            paciente.GraficarMatriz(); 
        }
        else
        {
            Console.WriteLine($"Paciente '{nombrePaciente}' no encontrado en la lista.");
        }
    }
}