using ProjetoCalculadoraSeguroDesemprego.Interfaces;
using ProjetoCalculadoraSeguroDesemprego.Models;

namespace ProjetoCalculadoraSeguroDesemprego.Services
{
    public class CalculoSeguroDesempregoService: ICalculoSeguroDesempregoService
    {
        private readonly ICalculadoraSeguroDesempregoService _calculoSeguroDesemprego;
        private readonly ICalculadoraMesesTrabalhadosService _calculoMesesTrabalhados;

        public CalculoSeguroDesempregoService(ICalculadoraSeguroDesempregoService calculoSeguroDesemprego, ICalculadoraMesesTrabalhadosService calculoMesesTrabalhados)
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
