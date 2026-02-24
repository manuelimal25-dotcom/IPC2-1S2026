using Semana_5.Clases;
namespace Semana_5.Lista_Simple
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

        public void SetSiguiente(Nodo? siguiente)
        {
            this.siguiente = siguiente;
        }
    }
}