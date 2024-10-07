

namespace ArmaProperty.Domain.Entities;
[Index(nameof(FullName), IsUnique = true)]
[Index(nameof(NationalId), IsUnique = true)]
[Index(nameof(PhoneNumber), IsUnique = true)]
public class Owner : Entity<int>
{
    public string FullName { get; set; }=string.Empty;
    public int NationalId { get; set; }
    public int PhoneNumber { get; set; }
    public string? ImageNationalId_F { get; set; }
    public string? ImageNationalId_B { get; set; }
    public string? Details { get; set; }

    public virtual ICollection<Property>? Properties { get; set; } = new List<Property>();

}
