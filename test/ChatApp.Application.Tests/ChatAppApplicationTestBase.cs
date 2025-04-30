using Volo.Abp.Modularity;

namespace ChatApp;

public abstract class ChatAppApplicationTestBase<TStartupModule> : ChatAppTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
