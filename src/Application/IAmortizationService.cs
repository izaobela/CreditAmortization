using ProjetoIntegrador.Domain;
using System.Threading.Tasks;

namespace ProjetoIntegrador.Application
{
    public interface IAmortizationService
    {
        Task<Contract> CalculateAmortization(AmortizationInput input);
        Task<Contract> GetAmortization(long document);
    }
}