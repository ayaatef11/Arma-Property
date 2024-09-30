using MyBookStore.Samples;
using Xunit;

namespace MyBookStore.EntityFrameworkCore.Applications;

[Collection(MyBookStoreTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<MyBookStoreEntityFrameworkCoreTestModule>
{

}
