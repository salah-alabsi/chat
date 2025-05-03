using ChatApp.Chat.Dto;
using ChatApp.Chat;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Users;
using Microsoft.AspNetCore.Authorization;
using ChatApp.SignalR;

namespace ChatApp.ChatAppService
{
    [Authorize]
    public class MessageAppService : ApplicationService, IMessageAppService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly ICurrentUser _currentUser;  // Inject ICurrentUser to get the current user's info
        private readonly IMapper _mapper;
        private readonly INotificationSender _notificationSender;

        public MessageAppService(IMessageRepository messageRepository, IMapper mapper, CurrentUser currentUser, INotificationSender notificationSender)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
            _currentUser = currentUser;  // Initialize the current user
            _notificationSender = notificationSender;
        }

        public async Task<MessageDto> SendPrivateMessageAsync(Guid receiverId, string text)
        {
            var senderId = _currentUser.Id;

            var message = new Message(GuidGenerator.Create(), senderId.Value, text, receiverId);
            await _messageRepository.InsertAsync(message);
            await _notificationSender.SendPrivateMessageAsync(receiverId, text);
            return _mapper.Map<MessageDto>(message);
        }

        public async Task<MessageDto> SendGroupMessageAsync(Guid senderId, Guid groupId, string text)
        {
            var message = new Message(GuidGenerator.Create(), senderId, text, null, groupId);
            await _messageRepository.InsertAsync(message);
             await _notificationSender.SendGroupMessageAsync(groupId, text);
            return _mapper.Map<MessageDto>(message);
        }

        public async Task<List<ResponseMessageDto>> GetMyPrivateMessagesAsync()
        {
            var userId = _currentUser.Id;
            var messages = await _messageRepository.GetListAsync(x => x.ReceiverId == userId || x.SenderId == userId);
            return _mapper.Map<List<ResponseMessageDto>>(messages);
        }

        public async Task<List<MessageDto>> GetGroupMessagesAsync(Guid groupId)
        {
            var messages = await _messageRepository.GetListAsync(x => x.GroupId == groupId);
            return _mapper.Map<List<MessageDto>>(messages);
        }
    }
}
