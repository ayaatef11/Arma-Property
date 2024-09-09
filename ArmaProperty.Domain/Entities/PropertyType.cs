
namespace ArmaProperty.Domain.Entities
{
    [Index(nameof(Name),IsUnique = true)]
    public class PropertyType
    {
        public int Id {  get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Property>? Properties { get; set; } = new List<Property>();
    }
}
