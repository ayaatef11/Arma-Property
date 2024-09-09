
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ArmaProperty.Infrastructure.ViewModel.PropertyViewModels
{
    public class PropertyViewModel
    {
        public IEnumerable<SelectListItem> Owners { get; set; } = new List<SelectListItem>();
        public IEnumerable<SelectListItem> PropertyType { get; set; } = new List<SelectListItem>();
        public IEnumerable<SelectListItem> PropertyStatus { get; set; } = new List<SelectListItem>();

        public PropertyAddEditViewModel PropertyAddEditViewModel { get; set; } = new PropertyAddEditViewModel();
    }
    public class PropertyAddEditViewModel
    {
        public int? Id { get; set; }
        
        [DisplayName("مالك العقار")]
        [Required(ErrorMessage = "مالك العقار مطلوب")]
        public int OwnerId { get; set; }

        [DisplayName("حالة العقار")]
        [Required(ErrorMessage = "حالة العقار مطلوبة")]
        public int PropertyStatusId { get; set; }

        [DisplayName("نوع العقار")]
        [Required(ErrorMessage = "نوع العقار مطلوب")]
        public int PropertyTypeId { get; set; }

        [DisplayName("اسم العقار")]
        [MaxLength(100, ErrorMessage = "اسم العقار لا يمكن أن يتجاوز 100 حرف")]
        [MinLength(2, ErrorMessage = "اسم العقار يجب أن يكون أكثر من حرفين")]
        [Required(ErrorMessage = "اسم العقار مطلوب")]
        public string Name { get; set; } = null!;

        [DisplayName("مساحة العقار")]
        public string? Area { get; set; }

        [DisplayName("الإيجار المطلوب")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "أدخل القيمة بالأرقام فقط")]
        [Required(ErrorMessage = "الإيجار مطلوب")]
        // double
        public string Rent { get; set; } = null!;

        [DisplayName("وصف العقار")]
        [MaxLength(500)]
        public string? Description { get; set; }
        
    }
}
