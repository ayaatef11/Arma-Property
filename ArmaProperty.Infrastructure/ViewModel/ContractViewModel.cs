using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmaProperty.Infrastructure.ViewModel
{
    public  class ContractViewModel
    {
        public int ContractId { get; set; }

        public int CotractStatusId { get; set; }
        [ForeignKey(nameof(CotractStatusId))]
        public virtual ContractStatus? ContractStatus { get; set; }//navigation property

        public int TenantId { get; set; }
        [ForeignKey(nameof(TenantId))]
        public virtual Tenant? Tenant { get; set; }//

        public int PropertyId { get; set; }
        [ForeignKey(nameof(PropertyId))]
        public virtual Property? Property { get; set; }//

        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public decimal Rent { get; set; }
        public decimal Insurance { get; set; }
        public string? Description { get; set; }


        public virtual ICollection<ContractDetails>? ContractDetails { get; set; } = new List<ContractDetails>();

        public ContractViewModel Equals(Contract contract)
        {
            return new ContractViewModel
            {
                ContractId = contract.Id,
                CotractStatusId = contract.CotractStatusId,
                TenantId = contract.TenantId,
                PropertyId = contract.PropertyId,
                ContractDetails = contract.ContractDetails,
                ContractStatus = contract.ContractStatus,
                Tenant = contract.Tenant,
                Property = contract.Property,
                FromDate = contract.FromDate,
                ToDate = contract.ToDate,
                Rent = contract.Rent,
                Insurance = contract.Insurance,
                Description = contract.Description
            };
        }
    }
}
