namespace Semana_8.Models
{
    // Representa un sistema de drones con su configuración
    public class Sistema
    {
        private string nombreSistema;
        private int alturaMaxima;
        private int cantidadDrones;
        private ListaContenido listaContenido;

        public Sistema(string nombreSistema, int alturaMaxima, int cantidadDrones, ListaContenido listaContenido)
        {
            this.nombreSistema = nombreSistema;
            this.alturaMaxima = alturaMaxima;
            this.cantidadDrones = cantidadDrones;
            this.listaContenido = listaContenido;
        }

        public string GetNombreSistema()
        {
            return nombreSistema;
        }

        public void SetNombreSistema(string nombreSistema)
        {
            this.nombreSistema = nombreSistema;
        }

        public int GetAlturaMaxima()
        {
            return alturaMaxima;
        }

        public void SetAlturaMaxima(int alturaMaxima)
        {
            this.alturaMaxima = alturaMaxima;
        }

        public int GetCantidadDrones()
        {
            return cantidadDrones;
        }

        public void SetCantidadDrones(int cantidadDrones)
        {
            this.cantidadDrones = cantidadDrones;
        }

        public ListaContenido GetListaContenido()
        {
            return listaContenido;
        }

        public void SetListaContenido(ListaContenido listaContenido)
        {
            this.listaContenido = listaContenido;
        }
    }
}