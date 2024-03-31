using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjetoIntegrador.Application;
using ProjetoIntegrador.Domain;

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
        public Contract CalculateAmortization(AmortizationInput amortizationInput)
        {
            _logger.LogInformation("Log de teste");
            return _amortizationService.CalculateAmortization(amortizationInput);
        }
    }
}
