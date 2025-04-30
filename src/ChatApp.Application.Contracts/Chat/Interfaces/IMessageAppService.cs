using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ChatApp.Chat.Dto;

namespace ChatApp.Chat
{
    public interface IMessageAppService
    {
        Task<MessageDto> SendPrivateMessageAsync( Guid receiverId, string text);
        Task<MessageDto> SendGroupMessageAsync(Guid senderId, Guid groupId, string text);
        Task<List<ResponseMessageDto>> GetMyPrivateMessagesAsync();
        Task<List<MessageDto>> GetGroupMessagesAsync(Guid groupId);
    }
}
