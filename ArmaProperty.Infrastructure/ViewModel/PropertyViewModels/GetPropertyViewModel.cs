
namespace ArmaProperty.Infrastructure.ViewModel.PropertyViewModels
{
    public class GetPropertyViewModel
    {
        public int Id { get; set; }
        public string? OwnerName { get; set; }
        public string? PropertyStatusName { get; set; }
        public string? PropertyTypeName { get; set; }
        public string Name { get; set; } = null!;
        public string? Area { get; set; }
        public string Rent { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
