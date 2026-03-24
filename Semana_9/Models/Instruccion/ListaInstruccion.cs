namespace Semana_8.Models
{
    // Lista doblemente enlazada de instrucciones
    public class ListaInstruccion
    {
        private NodoInstruccion? cabeza;
        private NodoInstruccion? cola;

        public ListaInstruccion()
        {
            cabeza = null;
            cola = null;
        }

        // Método para insertar una instrucción al final de la lista
        public void InsertarInstruccion(Instruccion nuevaInstruccion)
        {
            NodoInstruccion nuevoNodo = new NodoInstruccion(nuevaInstruccion);

            if (cabeza == null)
            {
                cabeza = nuevoNodo;
                cola = nuevoNodo;
            }
            else
            {
                cola.SetSiguiente(nuevoNodo);
                nuevoNodo.SetAnterior(cola);
                cola = nuevoNodo;
            }
        }
        public string MostrarInstrucciones()
        {
            string resultado = "";
            NodoInstruccion? actual = cabeza;

            while (actual != null)
            {
                Instruccion instruccion = actual.GetDato();
                resultado += $"Dron: {instruccion.GetNombreDron()}, Altura: {instruccion.GetAltura()}\n";
                actual = actual.GetSiguiente();
            }

            return resultado;
        }
    }
}