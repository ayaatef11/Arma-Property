using MyBookStore.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace MyBookStore.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(ArmaPropertyEntityFrameworkCoreModule),
    typeof(ArmaPropertyApplicationContractsModule)
    )]
public class ArmaPropertyDbMigratorModule : AbpModule
{
}
