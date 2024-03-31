using ProjetoIntegrador.Domain;

namespace ProjetoIntegrador.Application
{
    public interface IAmortizationService
    {
        public Contract CalculateAmortization(AmortizationInput input);
    }
}