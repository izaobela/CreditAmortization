using ProjetoIntegrador.Domain;

namespace ProjetoIntegrador.Application
{
    public class AmortizationInput
    {
        public long Document { get; set; }
        public int InstallmentsNumber { get; set; }
        public int AmortizationType { get; set; }
        public double CET { get; set; }
        public double BalanceValue { get; set; }
        public double AmortizationValue { get; set; }
    }
}