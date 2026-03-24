namespace Semana_8.Models
{
    // Nodo para lista doblemente enlazada de sistemas
    public class NodoSistema
    {
        private Sistema dato;
        private NodoSistema? siguiente;
        private NodoSistema? anterior;

        public NodoSistema(Sistema dato)
        {
            this.dato = dato;
            this.siguiente = null;
            this.anterior = null;
        }

        public Sistema GetDato()
        {
            return dato;
        }

        public NodoSistema? GetSiguiente()
        {
            return siguiente;
        }

        public void SetSiguiente(NodoSistema? siguiente)
        {
            this.siguiente = siguiente;
        }

        public NodoSistema? GetAnterior()
        {
            return anterior;
        }

        public void SetAnterior(NodoSistema? anterior)
        {
            this.anterior = anterior;
        }
    }
}