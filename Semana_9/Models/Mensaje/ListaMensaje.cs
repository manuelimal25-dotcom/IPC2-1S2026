namespace Semana_8.Models
{
    public class ListaMensaje
    {
        private NodoMensaje? cabeza;
        private NodoMensaje? cola;

        public ListaMensaje()
        {
            cabeza = null;
            cola = null;
        }

        // Método para insertar un mensaje al final de la lista
        public void InsertarMensaje(Mensaje mensaje)
        {
            NodoMensaje nuevoNodo = new NodoMensaje(mensaje);

            if (cabeza == null)
            {
                cabeza = nuevoNodo;
                cola = nuevoNodo;
            }
            else
            {
                cola!.SetSiguiente(nuevoNodo);
                cola = nuevoNodo;
            }
        }

        public string MostrarMensajes()
        {
            string resultado = "";
            NodoMensaje? actual = cabeza;

            while (actual != null)
            {
                Mensaje mensaje = actual.GetDato();
                resultado += $"Nombre: {mensaje.GetNombre()}, Sistema: {mensaje.GetSistema()}\n";
                resultado += "Instrucciones:\n";
                resultado += mensaje.GetListaInstrucciones().MostrarInstrucciones();
                actual = actual.GetSiguiente();
            }

            return resultado;
        }

        public NodoMensaje? GetCabeza()
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