namespace Semana_8.Models
{
    // Nodo para lista doblemente enlazada de contenidos
    public class NodoContenido
    {
        private Contenido dato;
        private NodoContenido? siguiente;
        private NodoContenido? anterior;

        public NodoContenido(Contenido dato)
        {
            this.dato = dato;
            this.siguiente = null;
            this.anterior = null;
        }

        public Contenido GetDato()
        {
            return dato;
        }

        public NodoContenido? GetSiguiente()
        {
            return siguiente;
        }

        public void SetSiguiente(NodoContenido? siguiente)
        {
            this.siguiente = siguiente;
        }

        public NodoContenido? GetAnterior()
        {
            return anterior;
        }

        public void SetAnterior(NodoContenido? anterior)
        {
            this.anterior = anterior;
        }
    }
}