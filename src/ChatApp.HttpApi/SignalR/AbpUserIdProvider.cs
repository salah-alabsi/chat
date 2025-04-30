using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

public class AbpUserIdProvider : IUserIdProvider
{
    public string GetUserId(HubConnectionContext connection)
    {
        // ABP sets the NameIdentifier claim to the user ID
        // return connection.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        // OR, depending on token:
        // return connection.User?.FindFirst("sub")?.Value;
         return connection.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value
        ?? connection.User?.FindFirst("sub")?.Value;
    }
}
