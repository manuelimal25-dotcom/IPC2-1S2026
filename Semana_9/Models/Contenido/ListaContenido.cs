namespace Semana_8.Models
{
    // Lista doblemente enlazada de contenidos (configuración dron-altura-letra)
    public class ListaContenido
    {
        private NodoContenido? cabeza;
        private NodoContenido? cola;

        public ListaContenido()
        {
            cabeza = null;
            cola = null;
        }

        // Inserta un contenido al final de la lista
        public void InsertarContenido(Contenido nuevoContenido)
        {
            NodoContenido nuevoNodo = new NodoContenido(nuevoContenido);

            // Si la lista está vacía
            if (cabeza == null)
            {
                cabeza = nuevoNodo;
                cola = nuevoNodo;
            }
            else
            {
                // Insertar al final
                nuevoNodo.SetAnterior(cola);
                cola!.SetSiguiente(nuevoNodo);
                cola = nuevoNodo;
            }
        }

        public NodoContenido? GetCabeza()
        {
            return cabeza;
        }

        public void InicializarLista()
        {
            cabeza = null;
            cola = null;
        }
    }
}