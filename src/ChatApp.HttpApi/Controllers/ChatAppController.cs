using ChatApp.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ChatApp.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class ChatAppController : AbpControllerBase
{
    protected ChatAppController()
    {
        LocalizationResource = typeof(ChatAppResource);
    }
}
