// src/ChatApp.HttpApi/SignalR/NotificationSender.cs
using ChatApp.HttpApi.SignalR;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace ChatApp.SignalR
{
    public class NotificationSender : INotificationSender
    {
        private readonly IHubContext<ChatHub> _hubContext;

        public NotificationSender(IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task SendPrivateMessageAsync(Guid receiverId, string message)
        {
            Console.WriteLine($"Sending private message to {receiverId}: {message}");
        
                await _hubContext.Clients.User(receiverId.ToString()).SendAsync("ReceivePrivateMessage", message);

        }
    }
}
