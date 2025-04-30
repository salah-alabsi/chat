using ChatApp.Samples;
using Xunit;

namespace ChatApp.EntityFrameworkCore.Domains;

[Collection(ChatAppTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<ChatAppEntityFrameworkCoreTestModule>
{

}
