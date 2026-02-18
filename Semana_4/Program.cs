using System.Data;
using System.Diagnostics;
using Semana_4.Xml;
using Semana_4.Lista_Simple;
using Semana_4.Clases;

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
                    EliminarPaciente(ListaPacientes);
                    break;
                case "4":
                    ListaPacientes.RecorrerLista();
                    break;
                case "5":
                    BuscarPaciente(ListaPacientes);
                    break;
                case "6":
                    Console.WriteLine($"Tamaño de la lista: {ListaPacientes.GetTamanio()}");
                    break;
                case "7":
                    ImpirmirCeldasPaciente(ListaPacientes);
                    break;
                case "8":
                    ImprimirMatrizPaciente(ListaPacientes);
                    break;
                case "9":
                    LimpiarLista(ListaPacientes);
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
        Console.WriteLine("3. Eliminar Paciente de la Lista");
        Console.WriteLine("4. Recorrer Lista de Pacientes");
        Console.WriteLine("5. Buscar Paciente por Nombre");
        Console.WriteLine("6. Tamaño de la Lista");
        Console.WriteLine("7. Imprimir Celdas Contagiadas de un Paciente");
        Console.WriteLine("8. Imprimir Matriz de un Paciente");
        Console.WriteLine("9. Limpiar Lista De Paciente");
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

    public static void EliminarPaciente(ListaSimple ListaPacientes)
    {
        Console.Write("Ingrese el nombre del paciente a eliminar: ");
        string nombreEliminar = Console.ReadLine() ?? "";
        ListaPacientes.EliminarPaciente(nombreEliminar);
    }

    public static void BuscarPaciente(ListaSimple ListaPacientes)
    {
        Console.Write("Ingrese el nombre del paciente a buscar: ");
        string nombreBuscar = Console.ReadLine() ?? "";
        Nodo? nodoEncontrado = ListaPacientes.BuscarPaciente(nombreBuscar);
        if (nodoEncontrado != null)
        {
            Paciente pacienteEncontrado = nodoEncontrado.GetDato();
            Console.WriteLine("Paciente encontrado:");
            pacienteEncontrado.ImprimirDatosPaciente();
        }
        else
        {
            Console.WriteLine($"Paciente '{nombreBuscar}' no encontrado en la lista.");
        }
    }

    public static void ImpirmirCeldasPaciente(ListaSimple ListaPacientes)
    {
        Console.Write("Ingrese el nombre del paciente para imprimir sus celdas contagiadas: ");
        string nombrePaciente = Console.ReadLine() ?? "";
        Nodo? nodoPaciente = ListaPacientes.BuscarPaciente(nombrePaciente);
        if (nodoPaciente != null)
        {
            Paciente paciente = nodoPaciente.GetDato();
            paciente.ImprimirCeldas();
        }
        else
        {
            Console.WriteLine($"Paciente '{nombrePaciente}' no encontrado en la lista.");
        }
    }

    public static void ImprimirMatrizPaciente(ListaSimple ListaPacientes)
    {
        Console.Write("Ingrese el nombre del paciente para imprimir su matriz: ");
        string nombrePaciente = Console.ReadLine() ?? "";
        Nodo? nodoPaciente = ListaPacientes.BuscarPaciente(nombrePaciente);
        if (nodoPaciente != null)
        {
            Paciente paciente = nodoPaciente.GetDato();
            paciente.ImprimirMatriz();
        }
        else
        {
            Console.WriteLine($"Paciente '{nombrePaciente}' no encontrado en la lista.");
        }
    }

    public static void LimpiarLista(ListaSimple listaPacientes)
    {
        Console.WriteLine("Limpiando la lista de pacientes.");
        listaPacientes.LimpiarLista();
    }

}