namespace Semana_8.Models
{
    // Representa la configuración de un dron a una altura específica
    public class Contenido
    {
        private string nombreDron;
        private int altura;
        private string letra;

        public Contenido(string nombreDron, int altura, string letra)
        {
            this.nombreDron = nombreDron;
            this.altura = altura;
            this.letra = letra;
        }

        public string GetNombreDron()
        {
            return nombreDron;
        }

        public void SetNombreDron(string nombreDron)
        {
            this.nombreDron = nombreDron;
        }

        public int GetAltura()
        {
            return altura;
        }

        public void SetAltura(int altura)
        {
            this.altura = altura;
        }

        public string GetLetra()
        {
            return letra;
        }

        public void SetLetra(string letra)
        {
            this.letra = letra;
        }
    }
}