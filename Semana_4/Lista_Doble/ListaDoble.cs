using Semana_4.Clases;

namespace Semana_4.Lista_Doble
{
    public class ListaDoble
    {
        private Nodo? cabeza;
        private Nodo? cola;
        private int tamanio;

        public ListaDoble()
        {
            this.cabeza = null;
            this.cola = null;
            this.tamanio = 0;
        }

        // Inserta una nueva celda al final de la lista
        public void Insertar(Celda celda)
        {
            Nodo nuevoNodo = new Nodo(celda);

            if (cabeza == null)
            {
                // La lista está vacía, el nuevo nodo es cabeza y cola
                cabeza = nuevoNodo;
                cola = nuevoNodo;
            }
            else
            {
                // Agregar el nuevo nodo al final de la lista
                cola!.SetSiguiente(nuevoNodo);
                // Establecer el enlace hacia atrás desde el nuevo nodo a la cola actual
                nuevoNodo.SetAnterior(cola);
                // Actualizar la cola para que apunte al nuevo nodo
                cola = nuevoNodo;
            }
            tamanio++;
        }
        // Busca una celda por su posición (fila, columna) y la retorna (null si no existe)
        public Celda? Buscar(int fila, int columna)
        {
            // Recorre la lista desde la cabeza hasta la cola buscando la celda con la posición dada
            Nodo? actual = cabeza;
            while (actual != null)
            {
                Celda celda = actual.GetDato();
                if (celda.GetFila() == fila && celda.GetColumna() == columna)
                {
                    return celda;
                }
                actual = actual.GetSiguiente();
            }

            return null;
        }

        // Elimina una celda por su posición (fila, columna)
        public void Eliminar(int fila, int columna)
        {
            // Si la lista está vacía, no se puede eliminar nada
            if (cabeza == null)
            {
                Console.WriteLine("La lista está vacía.");
                return; 
            }
            // Recorre la lista buscando la celda con la posición dada
            Nodo? actual = cabeza;

            while (actual != null)
            {
                Celda celda = actual.GetDato();

                if (celda.GetFila() == fila && celda.GetColumna() == columna)
                {
                    // Caso 1: Es el único nodo
                    if (actual == cabeza && actual == cola)
                    {
                        cabeza = null;
                        cola = null;
                    }
                    // Caso 2: Es la cabeza (pero hay más nodos)
                    else if (actual == cabeza)
                    {
                        cabeza = cabeza.GetSiguiente();
                        cabeza!.SetAnterior(null);
                    }
                    // Caso 3: Es la cola
                    else if (actual == cola)
                    {
                        cola = cola.GetAnterior();
                        cola!.SetSiguiente(null);
                    }
                    // Caso 4: Está en medio
                    else
                    {
                        // Obtener los nodos anterior y siguiente al nodo actual
                        Nodo? anteriorNodo = actual.GetAnterior();
                        Nodo? siguienteNodo = actual.GetSiguiente();
                        // Enlazar el nodo anterior con el nodo siguiente, saltándose el nodo actual
                        anteriorNodo!.SetSiguiente(siguienteNodo);
                        siguienteNodo!.SetAnterior(anteriorNodo);
                    }
                    tamanio--;
                    Console.WriteLine($"Celda en posición ({fila}, {columna}) eliminada de la lista.");
                    return;
                }
                actual = actual.GetSiguiente();
            }
            Console.WriteLine("Celda no encontrada para eliminar.");
        }

        // Recorre la lista de inicio a fin e imprime cada celda
        public void Recorrer()
        {
            if (cabeza == null)
            {
                Console.WriteLine("La lista está vacía.");
                return;
            }
            // Obetner el nodo actual comenzando desde la cabeza
            Nodo? actual = cabeza;
            Console.WriteLine($"Rejilla de celdas ({tamanio} celdas):");
            Console.WriteLine("----------------------------");
            while (actual != null)
            {
                actual.GetDato().ImprimirDatosCelda();
                actual = actual.GetSiguiente();
            }
        }

        // Recorre la lista de fin a inicio
        public void RecorrerInverso()
        {
            if (cola == null)
            {
                Console.WriteLine("La lista está vacía.");
                return;
            }
            Console.WriteLine($"Rejilla de celdas ({tamanio} celdas):");
            Console.WriteLine("----------------------------");
            Nodo? actual = cola;
            while (actual != null)
            {
                actual.GetDato().ImprimirDatosCelda();
                actual = actual.GetAnterior();
            }
        }

        // Limpia completamente la lista
        public void LimpiarLista()
        {
            cabeza = null;
            cola = null;
            tamanio = 0;
            Console.WriteLine("Lista de celdas limpiada exitosamente.");
        }

        // Retorna el tamanio actual de la lista
        public int GetTamaño()
        {
            return tamanio;
        }
    }
}