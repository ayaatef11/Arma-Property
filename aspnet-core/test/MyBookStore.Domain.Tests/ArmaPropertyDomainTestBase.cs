using Volo.Abp.Modularity;

namespace MyBookStore;

/* Inherit from this class for your domain layer tests. */
public abstract class ArmaPropertyDomainTestBase<TStartupModule> : ArmaPropertyTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
