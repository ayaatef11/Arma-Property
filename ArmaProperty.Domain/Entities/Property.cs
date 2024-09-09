
namespace ArmaProperty.Domain.Entities
{
    [Index(nameof(Name), IsUnique = true)]
    public class Property
    {
        public int Id { get; set; }

        public int OwnerId { get; set; }
        [ForeignKey(nameof(OwnerId))]
        public virtual Owner? Owner { get; set; }

        public int PropertyStatusId { get; set; }
        [ForeignKey(nameof(PropertyStatusId))]
        public virtual PropertyStatus? PropertyStatus { get; set; }


        public int PropertyTypeId { get; set; }
        [ForeignKey(nameof(PropertyTypeId))]
        public virtual PropertyType? PropertyType { get; set; }

        public string Name { get; set; } = null!;
        public string? Area { get; set; }
        public string Rent { get; set; } = null!;
        public string? Description { get; set; }


        public virtual ICollection<Contract>? Contracts { get; set; } = new List<Contract>();

    }
}
