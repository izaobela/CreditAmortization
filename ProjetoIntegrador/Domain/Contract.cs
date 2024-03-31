using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIntegrador.Domain
{
    public class Contract
    {
        public IList<Installment> Installments { get; set; }
        public int InstallmentsNumber { get; set; }
        public AmortizationType AmortizationType { get; set; }
        public decimal CET { get; set; }
        public decimal Value { get; set; }
    }
}
