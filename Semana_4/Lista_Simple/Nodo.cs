using Semana_4.Clases;
namespace Semana_4.Lista_Simple
{
    public class Nodo
    {
        private Paciente dato;
        private Nodo? siguiente;

        public Nodo(Paciente dato)
        {
            this.dato = dato;
            this.siguiente = null;
        }

        public Paciente GetDato()
        {
            return dato;
        }

        public void SetDato(Paciente dato)
        {
            this.dato = dato;
        }

        public Nodo? GetSiguiente()
        {
            return siguiente;
        }

        public void SetSiguiente(Nodo siguiente)
        {
            this.siguiente = siguiente;
        }
    }
}