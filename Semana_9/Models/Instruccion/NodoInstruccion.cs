namespace Semana_8.Models
{
    // Nodo para lista de instrucciones
    public class NodoInstruccion
    {
        private Instruccion dato;
        private NodoInstruccion? siguiente;

        private NodoInstruccion? anterior;

        public NodoInstruccion(Instruccion dato)
        {
            this.dato = dato;
            this.siguiente = null;
            this.anterior = null;
        }

        public Instruccion GetDato()
        {
            return dato;
        }
        public NodoInstruccion? GetSiguiente()
        {
            return siguiente;
        }
        public void SetSiguiente(NodoInstruccion? siguiente)
        {
            this.siguiente = siguiente;
        }
        public NodoInstruccion? GetAnterior()
        {
            return anterior;
        }
        public void SetAnterior(NodoInstruccion? anterior)
        {
            this.anterior = anterior;
        }
        
    }
}