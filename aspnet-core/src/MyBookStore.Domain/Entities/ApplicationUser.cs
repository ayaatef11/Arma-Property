
using Volo.Abp.Identity;

namespace ArmaProperty.Domain.Entities;
[Index(nameof(FullName),IsUnique =true)]
public class ApplicationUser : IdentityUser
{
    public string FullName { get; set; } = null!;

    public string? ImageName { get; set; }

    //is active is a property inhereited from it 
}
