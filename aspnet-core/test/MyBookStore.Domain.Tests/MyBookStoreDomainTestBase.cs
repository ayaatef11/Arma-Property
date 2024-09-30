using Volo.Abp.Modularity;

namespace MyBookStore;

/* Inherit from this class for your domain layer tests. */
public abstract class MyBookStoreDomainTestBase<TStartupModule> : MyBookStoreTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
