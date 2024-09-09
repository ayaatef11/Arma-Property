using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmaProperty.Infrastructure.ViewModel
{
    public  class TenantViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string NationalIdentity { get; set; } = string.Empty;
        public int PhoneNumber { get; set; }
        public string? ImageNationalId_F { get; set; }
        public string? ImageNationalId_B { get; set; }

        public string? Details { get; set; }

        public virtual ICollection<Contract>? Contracts { get; set; } = new List<Contract>();
        /* public static TenantViewModel operator =(Tenant tenant)
         {
             return new TenantViewModel
             {
                 Id = tenant.Id,
                 FullName = tenant.FullName,
                 NationalIdentity = tenant.NationalIdentity,
                 PhoneNumber = tenant.PhoneNumber,
                 ImageNationalId_F = tenant.ImageNationalId_F,
                 ImageNationalId_B = tenant.ImageNationalId_B,
                 Details = tenant.Details,
                 Contracts = tenant.Contracts
             };
         }*/
        public  TenantViewModel Equals(Tenant tenant)
        {
            return new TenantViewModel
            {
                Id = tenant.Id,
                FullName = tenant.FullName,
                NationalIdentity = tenant.NationalIdentity,
                PhoneNumber = tenant.PhoneNumber,
                ImageNationalId_F = tenant.ImageNationalId_F,
                ImageNationalId_B = tenant.ImageNationalId_B,
                Details = tenant.Details,
                Contracts = tenant.Contracts
            };
        }
        }
}
