using Semana_4.Clases;
namespace Semana_4.Lista_Doble
{
    public class Nodo
    {
        private Celda dato;
        private Nodo? siguiente;
        private Nodo? anterior;

        public Nodo(Celda dato)
        {
            this.dato = dato;
            this.siguiente = null;
            this.anterior = null;
        }

        public Celda GetDato()
        {
            return dato;
        }

        public void SetDato(Celda dato)
        {
            this.dato = dato;
        }

        public Nodo? GetSiguiente()
        {
            return siguiente;
        }

        public void SetSiguiente(Nodo? siguiente)
        {
            this.siguiente = siguiente;
        }

        public Nodo? GetAnterior()
        {
            return anterior;
        }

        public void SetAnterior(Nodo? anterior)
        {
            this.anterior = anterior;
        }
    }
}