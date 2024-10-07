

namespace ArmaProperty.Domain.Entities
{
    [Index(nameof(Name),IsUnique =true)]// to improve the quey performance,but status can't be unique?
    /*This is important when:

 You want to prevent duplicate entries in your ContractStatus table.
 The Name field should be unique for business reasons. For example, having two contract statuses called "Active" might cause confusion and inconsistency.*/
    public class ContractStatus : Entity<int>
    {
        public string Name { get; set; }=string.Empty;

        public virtual ICollection<Contract>? Contracts { get; set; } = new List<Contract>();
    }
}
