using Microsoft.AspNetCore.Mvc;
using ChatApp.Chat.Dto;

using System;
using System.Threading.Tasks;
using ChatApp.Chat;
using ChatApp.Application.Contracts.Chat.Dtos;

namespace ChatApp.HttpApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageApiController : ControllerBase
    {
        private readonly IMessageAppService _messageAppService;

        public MessageApiController(IMessageAppService messageAppService)
        {
            _messageAppService = messageAppService;
        }

        // API endpoint to send a private message
        [HttpPost("send/private")]
        public async Task<IActionResult> SendPrivateMessage([FromBody] SendPrivateMessageDto input)
        {
            if (input == null || string.IsNullOrEmpty(input.Text))
            {
                return BadRequest("Message text is required.");
            }

            // Sending private message via service
            var messageDto = await _messageAppService.SendPrivateMessageAsync(input);

            // Return the message DTO as a successful response
            return Ok(messageDto); // Message DTO is returned inside OkResult
        }

        // API endpoint to send a message to a group
        [HttpPost("send/group")]
        public async Task<IActionResult> SendGroupMessage([FromBody] SendGroupMessageDto input)
        {
            if (input == null || string.IsNullOrEmpty(input.Text) || input.GroupId == Guid.Empty)
            {
                return BadRequest("Invalid message or group.");
            }

            // Sending group message via service
            var messageDto = await _messageAppService.SendGroupMessageAsync(input.SenderId, input.GroupId, input.Text);

            // Return the message DTO as a successful response
            return Ok(messageDto); // Message DTO is returned inside OkResult
        }

        // API endpoint to get private messages for a user
        [HttpGet("private")]
        public async Task<IActionResult> GetPrivateMessages()
        {
            var messages = await _messageAppService.GetMyPrivateMessagesAsync();

            // Return the list of message DTOs as a response
            return Ok(messages); // A list of MessageDto will be returned inside OkResult
        }

        // API endpoint to get messages in a group
        [HttpGet("group/{groupId}")]
        public async Task<IActionResult> GetGroupMessages(Guid groupId)
        {
            var messages = await _messageAppService.GetGroupMessagesAsync(groupId);

            // Return the list of message DTOs as a response
            return Ok(messages); // A list of MessageDto will be returned inside OkResult
        }
    }

  
}
