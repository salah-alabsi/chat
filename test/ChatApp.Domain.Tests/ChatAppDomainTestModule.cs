using Volo.Abp.Modularity;

namespace ChatApp;

[DependsOn(
    typeof(ChatAppDomainModule),
    typeof(ChatAppTestBaseModule)
)]
public class ChatAppDomainTestModule : AbpModule
{

}
