namespace Semana_8.Models
{
    public class Instruccion
    {
        private string NombreDron;
        private string Altura;

        public Instruccion(string nombreDron, string altura)
        {
            NombreDron = nombreDron;
            Altura = altura;
        }

        public string GetNombreDron()
        {
            return NombreDron;
        }

        public void SetNombreDron(string nombreDron)
        {
            NombreDron = nombreDron;
        }

        public string GetAltura()
        {
            return Altura;
        }

        public void SetAltura(string altura)
        {
            Altura = altura;
        }
    
    }
}