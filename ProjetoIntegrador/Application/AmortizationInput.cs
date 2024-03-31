using ProjetoIntegrador.Domain;

namespace ProjetoIntegrador.Application
{
    public class AmortizationInput
    {
        public int InstallmentsNumber { get; set; }
        public AmortizationType AmortizationType { get; set; }
        public decimal CET { get; set; }
        public decimal Value { get; set; }
    }
}
