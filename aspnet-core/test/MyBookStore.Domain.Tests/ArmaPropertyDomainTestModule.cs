using Volo.Abp.Modularity;

namespace MyBookStore;

[DependsOn(
    typeof(ArmaPropertyDomainModule),
    typeof(ArmaPropertyTestBaseModule)
)]
public class ArmaPropertyDomainTestModule : AbpModule
{

}
