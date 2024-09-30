
namespace ArmaProperty.Domain.Entities
{
    [Index(nameof(Name),IsUnique =true)]
    public  class ContractStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;

        public virtual ICollection<Contract>? Contracts { get; set; } = new List<Contract>();
    }
}
