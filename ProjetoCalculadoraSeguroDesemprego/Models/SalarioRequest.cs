namespace ProjetoCalculadoraSeguroDesemprego.Models
{
    public class SalarioRequest
    {
        public double UltimoSalario { get; set; }
        public double PenultimoSalario { get; set; }
        public double AntepenultimoSalario { get; set; }
        public int MesesTrabalhados { get; set; }
        public int VezesSolicitado { get; set; }
    }
}
