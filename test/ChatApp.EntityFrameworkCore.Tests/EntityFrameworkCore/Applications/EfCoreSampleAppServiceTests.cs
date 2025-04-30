using ChatApp.Samples;
using Xunit;

namespace ChatApp.EntityFrameworkCore.Applications;

[Collection(ChatAppTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<ChatAppEntityFrameworkCoreTestModule>
{

}
