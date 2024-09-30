using Volo.Abp.Modularity;

namespace MyBookStore;

[DependsOn(
    typeof(MyBookStoreDomainModule),
    typeof(MyBookStoreTestBaseModule)
)]
public class MyBookStoreDomainTestModule : AbpModule
{

}
