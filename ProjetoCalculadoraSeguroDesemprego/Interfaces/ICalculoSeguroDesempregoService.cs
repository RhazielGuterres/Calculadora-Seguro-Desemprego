using ProjetoCalculadoraSeguroDesemprego.Models;

namespace ProjetoCalculadoraSeguroDesemprego.Interfaces
{
    public interface ICalculoSeguroDesempregoService
    {
        public SeguroDesempregoResponse Calcular(SalarioRequest request);
    }
}
