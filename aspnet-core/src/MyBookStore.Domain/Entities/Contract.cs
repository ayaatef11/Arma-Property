


namespace ArmaProperty.Domain.Entities
{
    public class Contract:Entity<int>
    {
        public int CotractStatusId { get; set; }
        [ForeignKey(nameof(CotractStatusId))]
        public virtual ContractStatus? ContractStatus { get; set; }//navigation property
        public int TenantId { get; set; }
        [ForeignKey(nameof(TenantId))]
        public virtual Tenant? Tenant { get; set; }

        public int PropertyId { get; set; }
        [ForeignKey(nameof(PropertyId))]
        public virtual Property? Property { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }    
        public decimal Rent { get; set; }
        public decimal Insurance { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<ContractDetails>? ContractDetails { get; set; } = new List<ContractDetails>();
   //we can put operations related to contract here 
    }
}
