
namespace ArmaProperty.Domain.Entities;
[Index(nameof(FullName),IsUnique =true)]
public class ApplicationUser : IdentityUser
{
    public string FullName { get; set; } = null!;

    public string? ImageName { get; set; }

    public bool IsActive { get; set; } = true;
}
