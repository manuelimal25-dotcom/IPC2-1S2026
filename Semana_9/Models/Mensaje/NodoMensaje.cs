namespace Semana_8.Models
{
    public class NodoMensaje
    {
        private Mensaje Dato;
        private NodoMensaje? siguiente;
        private NodoMensaje? anterior;

        public NodoMensaje(Mensaje dato)
        {
            Dato = dato;
            this.siguiente = null;
            this.anterior = null;
        }

        public Mensaje GetDato()
        {
            return Dato;
        }

        public NodoMensaje? GetSiguiente()
        {
            return siguiente;
        }

        public void SetSiguiente(NodoMensaje? siguiente)
        {
            this.siguiente = siguiente;
        }

        public NodoMensaje? GetAnterior()
        {
            return anterior;
        }

        public void SetAnterior(NodoMensaje? anterior)
        {
            this.anterior = anterior;
        }
    }
}