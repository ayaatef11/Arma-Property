using Volo.Abp.Modularity;

namespace MyBookStore;

[DependsOn(
    typeof(ArmaPropertyApplicationModule),
    typeof(ArmaPropertyDomainTestModule)
)]
public class ArmaPropertyApplicationTestModule : AbpModule
{

}
