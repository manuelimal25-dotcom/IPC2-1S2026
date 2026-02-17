using Semana_4.Lista_Simple;
using Semana_4.Clases;

namespace Semana_4.Lista_Simple
{
    public class ListaSimple
    {
        private Nodo? cabeza;

        private int tamanio;

        public ListaSimple()
        {
            this.cabeza = null;
            this.tamanio = 0;
        }

        public int GetTamanio()
        {
            return tamanio;
        }

        // Inserta un nuevo paciente al final de la lista
        public void InsertarPaciente(Paciente paciente)
        {
            Nodo nuevoNodo = new Nodo(paciente);
            // Si la lista está vacía, el nuevo nodo se convierte en la cabeza
            if (cabeza == null)
            {
                cabeza = nuevoNodo;
                tamanio++;
            }
            else
            {
                // Si la lista no está vacía, se recorre hasta el final y se agrega el nuevo nodo
                Nodo actual = cabeza;
                while (actual.GetSiguiente() != null)
                {
                    // Avanza al siguiente nodo hasta llegar al final de la lista
                    actual = actual.GetSiguiente();
                }
                actual.SetSiguiente(nuevoNodo);
                tamanio++;
            }
        }

        // Eliminar un paciente de la lista por su nombre
        public void EliminarPaciente(string nombre)
        {
            if (cabeza == null)
            {
                Console.WriteLine("La lista está vacía. No se puede eliminar ningún paciente.");
                return;
            }

            // Si el paciente a eliminar es la cabeza de la lista
            if (cabeza.GetDato().GetNombre() == nombre)
            {
                cabeza = cabeza.GetSiguiente();
                tamanio--;
                Console.WriteLine($"Paciente '{nombre}' eliminado de la lista.");
                return;
            }

            // Recorrer la lista para encontrar el paciente a eliminar
            Nodo actual = cabeza;
            while (actual.GetSiguiente() != null)
            {
                if (actual.GetSiguiente().GetDato().GetNombre() == nombre)
                {
                    // Eliminar el nodo que contiene al paciente encontrado
                    // Se actualiza el enlace del nodo actual para saltar el nodo a eliminar
                    actual.SetSiguiente(actual.GetSiguiente().GetSiguiente());
                    tamanio--;
                    Console.WriteLine($"Paciente '{nombre}' eliminado de la lista.");
                    return;
                }
                actual = actual.GetSiguiente();
            }

            Console.WriteLine($"Paciente '{nombre}' no encontrado en la lista.");
        }
        // Recorre la lista e imprime los datos de cada paciente
        public void RecorrerLista()
        {
            Console.WriteLine("Lista Simplemente Enlazada de Pacientes:");
            Console.WriteLine("---------------------------------------");
            // Recorre la lista desde la cabeza hasta el final, imprimiendo los datos de cada paciente
            Nodo actual = cabeza;
            while (actual != null)
            {
                Paciente paciente = actual.GetDato();
                paciente.ImprimirDatosPaciente();
                actual = actual.GetSiguiente();
            }
        }
        // Buscar un paciente por su nombre y devolver el nodo que lo contiene
        public Nodo? BuscarPaciente(string nombre)
        {
            Nodo actual = cabeza;
            while (actual != null)
            {
                if (actual.GetDato().GetNombre() == nombre)
                {
                    return actual; // Retorna el nodo que contiene al paciente encontrado
                }
                actual = actual.GetSiguiente();
            }
            return null; // Retorna null si no se encuentra el paciente
        }
        
    }
}