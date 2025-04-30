using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;
using Microsoft.Extensions.Localization;
using ChatApp.Localization;

namespace ChatApp.Web;

[Dependency(ReplaceServices = true)]
public class ChatAppBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<ChatAppResource> _localizer;

    public ChatAppBrandingProvider(IStringLocalizer<ChatAppResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
