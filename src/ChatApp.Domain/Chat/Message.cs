using Volo.Abp.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace ChatApp.Chat
{
    
    public class Message : Entity<Guid>
    {
        
        [Required]
        public Guid SenderId { get; set; }
        public Guid? ReceiverId { get; set; } // null for group messages
        public Guid? GroupId { get; set; } // null for private messages
        public string Text { get; set; }
        public DateTime CreationTime { get; set; }

        private Message() { }

        public Message(Guid id, Guid senderId, string text, Guid? receiverId = null, Guid? groupId = null) : base(id)
        {
            SenderId = senderId;
            Text = text;
            ReceiverId = receiverId;
            GroupId = groupId;
            CreationTime = DateTime.Now;
        }
    }
}
