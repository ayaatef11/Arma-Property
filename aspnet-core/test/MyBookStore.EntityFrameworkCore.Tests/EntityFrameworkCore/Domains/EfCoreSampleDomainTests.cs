using MyBookStore.Samples;
using Xunit;

namespace MyBookStore.EntityFrameworkCore.Domains;

[Collection(MyBookStoreTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<MyBookStoreEntityFrameworkCoreTestModule>
{

}
