using ProjetoCalculadoraSeguroDesemprego.Models;

namespace ProjetoCalculadoraSeguroDesemprego.Services
{
    public class CalculoSeguroDesempregoService
    {
        private readonly CalculoSeguroDesemprego _calculoSeguroDesemprego;
        private readonly CalculoMesesTrabalhados _calculoMesesTrabalhados;

        public CalculoSeguroDesempregoService()
        {
            _calculoSeguroDesemprego = new CalculoSeguroDesemprego();
            _calculoMesesTrabalhados = new CalculoMesesTrabalhados();
        }

        public SeguroDesempregoResponse Calcular(SalarioRequest request)
        {
            double mediaSalarial = _calculoSeguroDesemprego.CalcularMediaSalarial(
                request.UltimoSalario, request.PenultimoSalario, request.AntepenultimoSalario);

            double parcela = _calculoSeguroDesemprego.CalcularParcela(mediaSalarial);

            int parcelas = _calculoMesesTrabalhados.CalcularParcelas(request.VezesSolicitado, request.MesesTrabalhados);

            return new SeguroDesempregoResponse
            {
                MediaSalarial = mediaSalarial,
                Parcela = parcela,
                Parcelas = parcelas
            };
        }
    }
}
