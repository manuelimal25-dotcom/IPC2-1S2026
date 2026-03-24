namespace Semana_8.Models
{
    // Nodo para lista doblemente enlazada de drones
    public class NodoDron
    {
        private Dron dato;
        private NodoDron? siguiente;
        private NodoDron? anterior;

        public NodoDron(Dron dato)
        {
            this.dato = dato;
            this.siguiente = null;
            this.anterior = null;
        }

        public Dron GetDato()
        {
            return dato;
        }

        public NodoDron? GetSiguiente()
        {
            return siguiente;
        }

        public void SetSiguiente(NodoDron? siguiente)
        {
            this.siguiente = siguiente;
        }

        public NodoDron? GetAnterior()
        {
            return anterior;
        }

        public void SetAnterior(NodoDron? anterior)
        {
            this.anterior = anterior;
        }
    }
}