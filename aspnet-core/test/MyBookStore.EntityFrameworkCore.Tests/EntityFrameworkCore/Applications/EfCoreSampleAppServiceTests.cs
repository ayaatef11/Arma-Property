using MyBookStore.Samples;
using Xunit;

namespace MyBookStore.EntityFrameworkCore.Applications;

[Collection(ArmaPropertyTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<ArmaPropertyEntityFrameworkCoreTestModule>
{

}
