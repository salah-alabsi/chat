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
using ChatApp.Application.Contracts.Chat.Dtos;
using Volo.Abp.Identity;
using Volo.Abp;

namespace ChatApp.ChatAppService
{
    [Authorize]
    public class MessageAppService : ApplicationService, IMessageAppService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly ICurrentUser _currentUser;  // Inject ICurrentUser to get the current user's info
        private readonly IMapper _mapper;
        private readonly INotificationSender _notificationSender;
        private readonly IIdentityUserAppService _identityUserAppService;


        public MessageAppService(
      IMessageRepository messageRepository,
      IMapper mapper,
      ICurrentUser currentUser,
      INotificationSender notificationSender,
      IIdentityUserAppService identityUserAppService)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
            _currentUser = currentUser;
            _notificationSender = notificationSender;
            _identityUserAppService = identityUserAppService;
            Console.WriteLine("MessageAppService created...");

        }

        public async Task<MessageDto> SendPrivateMessageAsync(SendPrivateMessageDto input)
        {
            if (input == null || string.IsNullOrEmpty(input.Text))
            {
                throw new ArgumentException("Message text is required.");
            }

            var userDto = await _identityUserAppService.FindByUsernameAsync(input.ReceiverUserName);
            if (userDto == null)
            {
                throw new UserFriendlyException($"User with username {input.ReceiverUserName} not found.");
            }
            var receiverId = userDto.Id;
            var text = input.Text;

            // Check if the current user is the sender
            if (_currentUser.Id == null)
            {
                throw new InvalidOperationException("Current user ID is not available.");
            }

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
