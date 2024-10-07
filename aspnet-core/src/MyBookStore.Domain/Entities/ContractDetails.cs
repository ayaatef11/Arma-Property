
using Volo.Abp.Domain.Entities;

namespace ArmaProperty.Domain.Entities
{
    public class ContractDetails:Entity<int>
    {

        public int ContractId { get; set; }
        [ForeignKey(nameof(ContractId))]
        public virtual Contract? Contract { get; set; }//lazy loading ,  Contract data will not be loaded from the database until it is accessed.

        public DateTime Month { get; set; }
        public decimal Commission { get; set; }
        public decimal Rent { get; set; }

    }
}
