using Xunit;

namespace MyBookStore.EntityFrameworkCore;

[CollectionDefinition(MyBookStoreTestConsts.CollectionDefinitionName)]
public class MyBookStoreEntityFrameworkCoreCollection : ICollectionFixture<MyBookStoreEntityFrameworkCoreFixture>
{

}
