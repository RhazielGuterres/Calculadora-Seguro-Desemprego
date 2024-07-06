namespace ProjetoCalculadoraSeguroDesemprego.Services
{
    public class CalculoMesesTrabalhados
    {
        public int CalcularParcelas(int vezesSolicitado, int mesesTrabalhados)
        {
            int parcelas = 0;

            switch (vezesSolicitado)
            {
                case 1:
                    if (mesesTrabalhados >= 12 && mesesTrabalhados <= 23)
                    {
                        parcelas = 4;
                    }
                    else if (mesesTrabalhados >= 24)
                    {
                        parcelas = 5;
                    }
                    break;

                case 2:
                    if (mesesTrabalhados >= 9 && mesesTrabalhados <= 11)
                    {
                        parcelas = 3;
                    }
                    else if (mesesTrabalhados >= 12 && mesesTrabalhados <= 23)
                    {
                        parcelas = 4;
                    }
                    else if (mesesTrabalhados >= 24)
                    {
                        parcelas = 5;
                    }
                    break;

                case 3:
                    if (mesesTrabalhados >= 6 && mesesTrabalhados <= 11)
                    {
                        parcelas = 3;
                    }
                    else if (mesesTrabalhados >= 12 && mesesTrabalhados <= 23)
                    {
                        parcelas = 4;
                    }
                    else if (mesesTrabalhados >= 24)
                    {
                        parcelas = 5;
                    }
                    break;

                default:
                    throw new ArgumentException("Número de vezes solicitado inválido.");
            }

            return parcelas;
        }
    }
}
