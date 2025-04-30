using Microsoft.AspNetCore.Authentication.JwtBearer;
using Localization.Resources.AbpUi;
using ChatApp.Localization;
using Volo.Abp.Account;
using Volo.Abp.SettingManagement;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.HttpApi;
using Volo.Abp.Localization;
using Volo.Abp.TenantManagement;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication;
using Volo.Abp.AspNetCore.Mvc;
using OpenIddict.EntityFrameworkCore.Models;
using Volo.Abp.AspNetCore.Mvc.AntiForgery;
using OpenIddict.Abstractions;
using Microsoft.AspNetCore.SignalR;
using ChatApp.HttpApi.SignalR; 

using OpenIddict.Server;
using OpenIddict.Server.AspNetCore;
using System;


using ChatApp.SignalR;

namespace ChatApp;

[DependsOn(
    typeof(ChatAppApplicationContractsModule),
    typeof(AbpPermissionManagementHttpApiModule),
    typeof(AbpSettingManagementHttpApiModule),
    typeof(AbpAccountHttpApiModule),
    typeof(AbpIdentityHttpApiModule),
    typeof(AbpTenantManagementHttpApiModule),
    typeof(AbpFeatureManagementHttpApiModule),
    typeof(Volo.Abp.AspNetCore.Authentication.JwtBearer.AbpAspNetCoreAuthenticationJwtBearerModule)
   
    
    
)]
public class ChatAppHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        // Configure JwtBearer manually via standard ASP.NET Core mechanism
        PreConfigure<AuthenticationBuilder>(builder =>
        {
            builder.AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.Authority = "https://localhost:44384";
                options.Audience = "ChatApp";
                options.RequireHttpsMetadata = true;
            });
        });
    }

   public override void ConfigureServices(ServiceConfigurationContext context)
{
    ConfigureLocalization();
    context.Services.AddSignalR();
    context.Services.AddTransient<INotificationSender, NotificationSender>();

 context.Services.AddSingleton<IUserIdProvider, AbpUserIdProvider>();

}

    private void ConfigureLocalization()
    {
        Configure<Volo.Abp.Localization.AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<ChatAppResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
