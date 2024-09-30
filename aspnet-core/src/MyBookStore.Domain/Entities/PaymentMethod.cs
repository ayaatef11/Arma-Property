
namespace ArmaProperty.Domain.Entities
{
    [Index(nameof(Name),IsUnique =true)]
    public  class PaymentMethod
    {
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;

        public virtual ICollection<Catch>? Catches { get; set; } = new List<Catch>();
        public virtual ICollection<Payment>? Payments { get; set; } = new List<Payment>();
    }
}
