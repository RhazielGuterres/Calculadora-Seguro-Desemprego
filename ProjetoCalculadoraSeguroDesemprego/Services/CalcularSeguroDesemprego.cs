using ProjetoCalculadoraSeguroDesemprego.Interfaces;

namespace ProjetoCalculadoraSeguroDesemprego.Services
{
    public class CalculoSeguroDesemprego : ICalculoSeguroDesemprego
    {
        public double CalcularMediaSalarial(double ultimoSalario, double penultimoSalario, double antepenultimoSalario)
        {
            return (ultimoSalario + penultimoSalario + antepenultimoSalario) / 3;
        }

        public double CalcularParcela(double mediaSalarial)
        {
            double parcela;
            if (mediaSalarial <= 2041.39)
            {
                parcela = mediaSalarial * 0.8;
                if (parcela < 1412)
                {
                    parcela = 1412;
                }
            }
            else if (mediaSalarial <= 3402.65)
            {
                parcela = ((mediaSalarial - 2041.39) * 0.5) + 1633.10;
            }
            else
            {
                parcela = 2313.74;
            }
            return parcela;
        }
    }

}
