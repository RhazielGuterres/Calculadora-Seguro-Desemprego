namespace ProjetoCalculadoraSeguroDesemprego.Interfaces
{
    public interface ICalculadoraSeguroDesempregoService
    {
        double CalcularMediaSalarial(double ultimoSalario, double penultimoSalario, double antepenultimoSalario);
        double CalcularParcela(double mediaSalarial);
    }
}
