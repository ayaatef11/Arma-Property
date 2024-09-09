

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ArmaProperty.Infrastructure.ViewModel;
public class OwnerViewModel
{
    public int? Id { get; set; }
    [DisplayName("اسم المالك")]
    [MaxLength(100)]
    public string FullName { get; set; } = string.Empty;
    public int NationalId { get; set; }
    [RegularExpression("")]
    public int PhoneNumber { get; set; }
 
    public string? ImageNationalId_F { get; set; }
    public string? ImageNationalId_B { get; set; }
    public string? Details { get; set; }

    public virtual ICollection<Property>? Properties { get; set; } = new List<Property>();
}
