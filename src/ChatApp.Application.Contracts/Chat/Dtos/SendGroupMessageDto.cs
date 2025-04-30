using System;

namespace ChatApp.Application.Contracts.Chat.Dtos
{
    public class SendGroupMessageDto
    {
        public Guid GroupId { get; set; }  // The ID of the group the message is being sent to
        public Guid SenderId { get; set; }  // The ID of the user sending the message
        public string Text { get; set; }  // The content of the message
        public DateTime CreationTime { get; set; }  // The time when the message was sent (optional, can be auto-generated)
    }
}
