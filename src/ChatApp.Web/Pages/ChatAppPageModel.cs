using ChatApp.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace ChatApp.Web.Pages;

public abstract class ChatAppPageModel : AbpPageModel
{
    protected ChatAppPageModel()
    {
        LocalizationResourceType = typeof(ChatAppResource);
    }
}
