namespace ArmaProperty.Infrastructure.Data;
public class ApplicationDbContext :IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
    {            
    }

    public virtual DbSet<Catch> Catches { get; set; }
    public virtual  DbSet<Contract> Contracts { get; set; }
    public virtual DbSet<ContractDetails> ContractDetails { get; set; }
    public virtual DbSet<ContractStatus> ContractStatuses { get; set; }
    public virtual DbSet<Owner> Owners { get; set; }
    public virtual DbSet<Payment> Payments { get; set; }
    public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }
    public virtual DbSet<Property> Properties { get; set; }
    public virtual DbSet<PropertyStatus> propertyStatuses { get; set; }
    public virtual DbSet<PropertyType> PropertyTypes { get; set; }
}
