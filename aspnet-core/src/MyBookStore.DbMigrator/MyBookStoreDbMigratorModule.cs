using MyBookStore.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace MyBookStore.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(MyBookStoreEntityFrameworkCoreModule),
    typeof(MyBookStoreApplicationContractsModule)
    )]
public class MyBookStoreDbMigratorModule : AbpModule
{
}
