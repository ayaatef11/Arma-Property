using Volo.Abp.Modularity;

namespace MyBookStore;

[DependsOn(
    typeof(ArmaPropertyApplicationModule),
    typeof(MyBookStoreDomainTestModule)
)]
public class MyBookStoreApplicationTestModule : AbpModule
{

}
