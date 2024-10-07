using Volo.Abp.Modularity;

namespace MyBookStore;

[DependsOn(
    typeof(ArmaPropertyDomainModule),
    typeof(MyBookStoreTestBaseModule)
)]
public class MyBookStoreDomainTestModule : AbpModule
{

}
