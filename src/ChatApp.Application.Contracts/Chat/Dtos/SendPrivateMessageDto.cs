using System;

namespace ChatApp.Application.Contracts.Chat.Dtos
{
    public class SendPrivateMessageDto
    {
               public Guid RecipientId { get; set; }  // The ID of the user receiving the message
        public string Text { get; set; }  // The content of the message
        public DateTime CreationTime { get; set; }  // The time when the message was sent (optional, can be auto-generated)
    }
}
