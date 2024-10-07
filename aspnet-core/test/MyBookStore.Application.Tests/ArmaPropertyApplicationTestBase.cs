using Volo.Abp.Modularity;

namespace MyBookStore;

public abstract class ArmaPropertyApplicationTestBase<TStartupModule> : ArmaPropertyTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
