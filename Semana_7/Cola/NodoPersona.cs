namespace Semana_7
{
    public class NodoPersona
    {
        private Persona dato;
        private NodoPersona? siguiente;

        public NodoPersona(Persona dato)
        {
            this.dato = dato;
            this.siguiente = null;
        }

        public Persona GetDato()
        {
            return dato;
        }

        public NodoPersona? GetSiguiente()
        {
            return siguiente;
        }

        public void SetSiguiente(NodoPersona? siguiente)
        {
            this.siguiente = siguiente;
        }
    }
}