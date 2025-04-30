using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;
using Volo.Abp.Users;

namespace ChatApp.HttpApi.SignalR
{
    public class ChatHub : Hub
    {
        private readonly ICurrentUser _currentUser;
        private readonly IGroupMemberAppService _groupMemberAppService;
        public ChatHub(ICurrentUser currentUser, IGroupMemberAppService groupMemberAppService)
        {
            _currentUser = currentUser;
            _groupMemberAppService = groupMemberAppService;
        }
        // Optionally add methods if you need (e.g., joining groups later)
        public override async Task OnConnectedAsync()
        {
            
            var userId = Context.UserIdentifier;

            Console.WriteLine($"[SignalR] User connected: {userId}");
            if (userId != null)
            {
                // Inject your repository however you're doing DI
                var groupMembersIds = await _groupMemberAppService.GetGroupIdsForUserAsync(_currentUser.GetId());
                foreach (var groupId in groupMembersIds)
                {
                     Console.WriteLine($"User {userId} added to group {groupId}");
                    await Groups.AddToGroupAsync(Context.ConnectionId, groupId.ToString());
                }
            }
            await base.OnConnectedAsync();
        }
        public async Task SendPrivate(string message)
        {
            var userId = Context.UserIdentifier;
            await Clients.User(userId).SendAsync("ReceivePrivateMessage", $"Echo: {message}");
        }
    }
}
