using ChatApp.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace ChatApp.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(ChatAppEntityFrameworkCoreModule),
    typeof(ChatAppApplicationContractsModule)
)]
public class ChatAppDbMigratorModule : AbpModule
{
}
