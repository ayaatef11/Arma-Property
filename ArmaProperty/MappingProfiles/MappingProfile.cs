
namespace ArmaProperty.Web.MappingProfiles;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Contract, ContractViewModel>().
                ForMember(dest => dest.ContractId, src => src.MapFrom(src => src.Id)).ReverseMap();

            CreateMap<Owner, OwnerViewModel>();
            CreateMap<Tenant, TenantViewModel>().ReverseMap();
            CreateMap<Property, PropertyAddEditViewModel>().ReverseMap();
        }
        
    }

