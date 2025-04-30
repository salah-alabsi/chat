using ChatApp.Chat;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.Account;
using Volo.Abp.Identity;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Modularity;
using Volo.Abp.TenantManagement;
using Volo.Abp.Application;

namespace ChatApp;

[DependsOn(
    typeof(ChatAppDomainModule),
    typeof(ChatAppApplicationContractsModule),
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpAccountApplicationModule),
    typeof(AbpTenantManagementApplicationModule),
    typeof(AbpSettingManagementApplicationModule),
       typeof(AbpDddApplicationModule),
    typeof(ChatAppApplicationContractsModule)
    )]
public class ChatAppApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<ChatAppApplicationModule>();
        });
        // Registering the repositories with dependency injection
        // context.Services.AddTransient<IGroupRepository>();
        // context.Services.AddTransient<IGroupMemberRepository>();

        // Registering other services if needed
        context.Services.AddAutoMapper(typeof(ChatAppApplicationModule));  // Register AutoMapper profiles
    }
}
