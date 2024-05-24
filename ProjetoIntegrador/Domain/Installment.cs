using System;
using System.ComponentModel.DataAnnotations;

namespace ProjetoIntegrador.Domain
{
    public class Installment
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public double Value { get; set; }
        public double ValueWithFee { get; set; }
        public int Number { get; set; }
    }
}