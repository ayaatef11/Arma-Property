using Volo.Abp.Modularity;

namespace MyBookStore;

public abstract class MyBookStoreApplicationTestBase<TStartupModule> : MyBookStoreTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
