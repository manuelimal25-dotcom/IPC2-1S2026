namespace Semana_8.Models
{
    public class Mensaje
    {
        private string Nombre;
        private string Sistema;
        private ListaInstruccion listaInstrucciones;

        public Mensaje(string nombre, string sistema, ListaInstruccion listaInstrucciones)
        {
            Nombre = nombre;
            Sistema = sistema;
            this.listaInstrucciones = listaInstrucciones;
        }

        public string GetNombre()
        {
            return Nombre;
        }

        public void SetNombre(string nombre)
        {
            Nombre = nombre;
        }

        public string GetSistema()
        {
            return Sistema;
        }

        public void SetSistema(string sistema)
        {
            Sistema = sistema;
        }

        public ListaInstruccion GetListaInstrucciones()
        {
            return listaInstrucciones;
        }

        public void SetListaInstrucciones(ListaInstruccion listaInstrucciones)
        {
            this.listaInstrucciones = listaInstrucciones;
        }

    }
}