
namespace ArmaProperty.Domain.Entities
{
    [Index(nameof(Name), IsUnique = true)]
    public  class PropertyStatus : Entity<int>
    {
        public string Name { get; set; }=string.Empty;

        public virtual ICollection<Property>? Properties { get; set; } = new List<Property>();
    }
}
