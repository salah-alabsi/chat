using Volo.Abp.Modularity;

namespace ChatApp;

/* Inherit from this class for your domain layer tests. */
public abstract class ChatAppDomainTestBase<TStartupModule> : ChatAppTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
