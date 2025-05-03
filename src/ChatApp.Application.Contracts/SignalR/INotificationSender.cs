
using System;
using System.Threading.Tasks;

namespace ChatApp.SignalR;

public interface INotificationSender
{
    Task SendPrivateMessageAsync(Guid receiverId, string message);
    Task SendGroupMessageAsync(Guid groupId, string message);
}
