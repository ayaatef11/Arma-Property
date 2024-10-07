
namespace ArmaProperty.Domain.Entities
{
    [Index(nameof(FullName),IsUnique =true)]    
    public class Tenante : Entity<int>
    {
        public string FullName { get; set; }=string.Empty;
        public string NationalIdentity { get; set; } = string.Empty;
        public int PhoneNumber { get; set; }
        public string? ImageNationalId_F { get; set; }
        public string? ImageNationalId_B { get; set; }

        public string? Details { get; set; }

        public virtual ICollection<Contract>? Contracts { get; set; } = new List<Contract>();
    }
}
