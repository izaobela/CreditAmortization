using ProjetoIntegrador.Domain;
using ProjetoIntegrador.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace ProjetoIntegrador.Application
{
    public class AmortizationService : IAmortizationService
    {
        private readonly AmortizationRepository _amortizationRepository;
        public AmortizationService(AmortizationRepository amortizationRepository)
        {
            _amortizationRepository = amortizationRepository;
            _amortizationRepository.Initialize();
        }

        public async Task<Contract> CalculateAmortization(AmortizationInput input)
        {
            var contractAlreadyExists = await GetAmortization(input.Document);
            if (contractAlreadyExists is not null)
            {
                return contractAlreadyExists;
            }

            var installments = new List<Installment>();

            var installmentValue = input.BalanceValue / input.InstallmentsNumber;
            input.CET /= 100;
            double monthlyFee = input.CET / 12;
            var valueForAmortization = input.AmortizationValue;
            double fee = monthlyFee * input.InstallmentsNumber;
            double totalDiscounts = 0;

            for (var i = input.InstallmentsNumber; i >= 1; i--)
            {
                var amortization = Math.Round(installmentValue * fee, 5);
                var newInstallment = installmentValue - amortization;
                if (valueForAmortization >= newInstallment)
                {
                    totalDiscounts = totalDiscounts + installmentValue - newInstallment;
                    valueForAmortization -= newInstallment;
                    installments.Add(new Installment { Number = i, ValueWithFee = installmentValue, Value = newInstallment });
                }
                else
                {
                    installments.Add(new Installment { Number = i, ValueWithFee = installmentValue, Value = installmentValue });
                }

                fee -= monthlyFee;
            }

            double totalPaid = 0;
            foreach (var installment in installments.OrderBy(x => x.Number))
            {
                if(installment.ValueWithFee - installment.Value != 0)
                {
                    totalPaid += installment.Value;
                }
            };

            var contract = new Contract
            {
                Document = input.Document,
                AmortizationType = input.AmortizationType,
                CET = input.CET,
                InstallmentsNumber = input.InstallmentsNumber,
                Value = input.BalanceValue,
                Installments = installments,
                Discounts = totalDiscounts,
                TotalPaid = totalPaid
            };

            _amortizationRepository.Contract.Add(contract);
            await _amortizationRepository.SaveChangesAsync();

            return contract;
        }

        public async Task<Contract> GetAmortization(long document)
        {
            var contract = await _amortizationRepository.Contract.FindAsync(document);
            return contract;
        }
    }
}