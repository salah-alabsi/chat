using Microsoft.AspNetCore.Builder;
using ChatApp;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
builder.Environment.ContentRootPath = GetWebProjectContentRootPathHelper.Get("ChatApp.Web.csproj"); 
await builder.RunAbpModuleAsync<ChatAppWebTestModule>(applicationName: "ChatApp.Web");

public partial class Program
{
}
