using Xunit;

namespace ChatApp.EntityFrameworkCore;

[CollectionDefinition(ChatAppTestConsts.CollectionDefinitionName)]
public class ChatAppEntityFrameworkCoreCollection : ICollectionFixture<ChatAppEntityFrameworkCoreFixture>
{

}
