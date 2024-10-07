using ArmaProperty.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookStore.EntityFramework
{
    internal class ArmaDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Catch>Catches { get; set; }
       public DbSet<Contract>Contracts { get; set; }
       public DbSet<ContractDetails>ContractDetails{ get; set; }
       public DbSet<ContractStatus>ContractStatus { get; set; }
       public DbSet<Owner>Owners { get; set; }
       public DbSet<Payment>Payments { get; set; }
       public DbSet<PaymentMethod>PaymentMethods { get; set; }
       public DbSet<Property>Properities { get; set; }
       public DbSet<PropertyStatus>PropertyStatues { get; set; }
       public DbSet<PropertyType>PropertyTypes { get; set; }
       public DbSet<Tenant>Tenants { get; set; }
    }
}
