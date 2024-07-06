using ProjetoCalculadoraSeguroDesemprego.Interfaces;
using ProjetoCalculadoraSeguroDesemprego.Models;

namespace ProjetoCalculadoraSeguroDesemprego.Services
{
    public class CalculoSeguroDesempregoService
    {
        private readonly ICalculoSeguroDesemprego _calculoSeguroDesemprego;
        private readonly ICalculoMesesTrabalhados _calculoMesesTrabalhados;

        public CalculoSeguroDesempregoService(ICalculoSeguroDesemprego calculoSeguroDesemprego, ICalculoMesesTrabalhados calculoMesesTrabalhados)
        {
            _calculoSeguroDesemprego = calculoSeguroDesemprego;
            _calculoMesesTrabalhados = calculoMesesTrabalhados;
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
