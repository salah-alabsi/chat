using System;

namespace ChatApp.Chat.Dto
{
    public class MessageDto
    {
        public Guid Id { get; set; }
        public Guid SenderId { get; set; }
        public string Text { get; set; }
        public DateTime CreationTime { get; set; }
    }
      public class ResponseMessageDto
    {
        public Guid Id { get; set; }
        public Guid SenderId { get; set; }

        
         public Guid ReceiverId { get; set; }
        public string Text { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
