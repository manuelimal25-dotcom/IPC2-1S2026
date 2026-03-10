namespace Semana_7
{
    public class NodoLibro
    {
        private Libro dato;
        private NodoLibro? siguiente;

        public NodoLibro(Libro dato)
        {
            this.dato = dato;
            this.siguiente = null;
        }

        public Libro GetDato()
        {
            return dato;
        }

        public NodoLibro? GetSiguiente()
        {
            return siguiente;
        }

        public void SetSiguiente(NodoLibro? siguiente)
        {
            this.siguiente = siguiente;
        }
    }
}