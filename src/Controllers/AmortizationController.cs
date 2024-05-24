using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjetoIntegrador.Application;
using ProjetoIntegrador.Domain;
using System.Threading.Tasks;

namespace ProjetoIntegrador.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AmortizationController : ControllerBase
    {
        private readonly ILogger<AmortizationController> _logger;
        private readonly IAmortizationService _amortizationService;

        public AmortizationController(ILogger<AmortizationController> logger, IAmortizationService amortizationService)
        {
            _logger = logger;
            _amortizationService = amortizationService;
        }

        [HttpPost]
        public async Task<Contract> CalculateAmortization(AmortizationInput amortizationInput)
        {
            _logger.LogInformation("Log de teste");
            return await _amortizationService.CalculateAmortization(amortizationInput);
        }

        [HttpGet]
        public async Task<Contract> GetAmortization(long document)
        {
            return await _amortizationService.GetAmortization(document);
        }
    }
}