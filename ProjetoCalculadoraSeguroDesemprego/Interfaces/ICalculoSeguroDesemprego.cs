namespace ProjetoCalculadoraSeguroDesemprego.Interfaces
{
    public interface ICalculoSeguroDesemprego
    {
        double CalcularMediaSalarial(double ultimoSalario, double penultimoSalario, double antepenultimoSalario);
        double CalcularParcela(double mediaSalarial);
    }
}
