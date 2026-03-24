namespace Semana_8.Models
{
    // Lista doblemente enlazada ordenada alfabéticamente
    public class ListaDrones
    {
        private NodoDron? cabeza;
        private NodoDron? cola;

        public ListaDrones()
        {
            cabeza = null;
            cola = null;
        }

        // Inserta un dron manteniendo el orden alfabético
        public void InsertarDron(Dron nuevoDron)
        {
            NodoDron nuevoNodo = new NodoDron(nuevoDron);

            // Si la lista está vacía
            if (cabeza == null)
            {
                cabeza = nuevoNodo;
                cola = nuevoNodo;
                return;
            }

            // Si debe insertarse antes de la cabeza
            if (string.Compare(nuevoDron.GetNombre(), cabeza.GetDato().GetNombre(), StringComparison.Ordinal) <= 0)
            {
                nuevoNodo.SetSiguiente(cabeza);
                cabeza.SetAnterior(nuevoNodo);
                cabeza = nuevoNodo;
                return;
            }

            // Buscar la posición adecuada en medio o al final
            NodoDron? actual = cabeza;
            while (actual.GetSiguiente() != null && string.Compare(nuevoDron.GetNombre(), actual.GetSiguiente().GetDato().GetNombre(), StringComparison.Ordinal) > 0)
            {
                actual = actual.GetSiguiente();
            }

            // Insertar el nodo en la posición encontrada
            nuevoNodo.SetSiguiente(actual.GetSiguiente());
            nuevoNodo.SetAnterior(actual);

            if (actual.GetSiguiente() != null)
            {
                actual.GetSiguiente().SetAnterior(nuevoNodo);
            }
            else
            {
                cola = nuevoNodo; // Si se inserta al final
            }

            actual.SetSiguiente(nuevoNodo);
        }

        // Obtiene la cabeza de la lista
        public NodoDron? GetCabeza()
        {
            return cabeza;
        }

        // Limpia toda la lista
        public void InicializarLista()
        {
            cabeza = null;
            cola = null;
        }

        // Genera string con todos los drones para mostrar en textarea
        public string ObtenerDronesTexto()
        {
            if (cabeza == null)
            {
                return "No hay drones registrados.";
            }

            string resultado = "LISTA DE DRONES (Ordenados Alfabéticamente)\n";
            resultado += "--------------------------------------------\n";

            NodoDron? actual = cabeza;
            int contador = 1;

            while (actual != null)
            {
                resultado += $"{contador}. {actual.GetDato().GetNombre()}\n";
                actual = actual.GetSiguiente();
                contador++;
            }

            return resultado;
        }
    }
}