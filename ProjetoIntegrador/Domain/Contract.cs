using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjetoIntegrador.Domain
{
    public class Contract
    {
        [Key]
        public long Document { get; set; }
        public IList<Installment> Installments { get; set; }
        public int InstallmentsNumber { get; set; }
        public int AmortizationType { get; set; }
        public double CET { get; set; }
        public double Value { get; set; }
        public double Discounts { get; set; }
        public double TotalPaid { get; set; }
    }
}
