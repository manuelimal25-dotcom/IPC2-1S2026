namespace frontend.Models
{
    public class Cliente
    {
        public string NIT { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public decimal Saldo { get; set; }
    }
}