
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ArmaProperty.Infrastructure.ViewModel.PropertyViewModels
{
    public class PropertyFiltersViewModel
    {
        // Filters Values
        public string? Search { get; set; }
        public int? OwnerId { get; set; }
        public int? PropertyTypeId { get; set; }
        public int? PropertyStatusId { get; set; }
    }

    public class PropertiesViewModel
    {
        public IEnumerable<SelectListItem> Owners { get; set; } = new List<SelectListItem>();
        public IEnumerable<SelectListItem> PropertyType { get; set; } = new List<SelectListItem>();
        public IEnumerable<SelectListItem> PropertyStatus { get; set; } = new List<SelectListItem>();
    }
}
