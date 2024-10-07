using MyBookStore.Samples;
using Xunit;

namespace MyBookStore.EntityFrameworkCore.Domains;

[Collection(ArmaPropertyTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<ArmaPropertyEntityFrameworkCoreTestModule>
{

}
