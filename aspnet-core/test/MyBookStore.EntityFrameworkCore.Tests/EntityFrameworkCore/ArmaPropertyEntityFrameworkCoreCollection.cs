using Xunit;

namespace MyBookStore.EntityFrameworkCore;

[CollectionDefinition(ArmaPropertyTestConsts.CollectionDefinitionName)]
public class ArmaPropertyEntityFrameworkCoreCollection : ICollectionFixture<ArmaPropertyEntityFrameworkCoreFixture>
{

}
