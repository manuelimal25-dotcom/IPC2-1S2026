namespace frontend.Models
{
    public class ResumenIngreso
    {
        public string Banco { get; set; } = string.Empty;
        public string Mes { get; set; } = string.Empty;
        public decimal Total { get; set; }
    }
}