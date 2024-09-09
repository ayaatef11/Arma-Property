
namespace ArmaProperty.Domain.Entities
{
    public class ContractDetails
    {
        public int Id { get; set; }

        public int ContractId { get; set; }
        [ForeignKey(nameof(ContractId))]
        public virtual Contract? Contract { get; set; }

        public DateTime Month { get; set; }
        public decimal Commission { get; set; }
        public decimal Rent { get; set; }

    }
}
