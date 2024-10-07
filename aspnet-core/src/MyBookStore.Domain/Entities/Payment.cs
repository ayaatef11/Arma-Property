
namespace ArmaProperty.Domain.Entities
{
    public  class Payment : Entity<int>
    {

        public string Name { get; set; } = null!;
        public int ContractDetailsId { get; set; }
        [ForeignKey("ContractDetailsId")]
        public virtual ContractDetails? ContractDetails { get; set; }

        public int PaymentMethodId { get; set; }
        [ForeignKey("PaymentMethodId")]
        public virtual PaymentMethod? PaymentMethod { get; set; }

        public DateTime CurrentDate { get; set; }
        public DateTime Date { get; set; }

        public string? Details { get; set; }

    }
}
