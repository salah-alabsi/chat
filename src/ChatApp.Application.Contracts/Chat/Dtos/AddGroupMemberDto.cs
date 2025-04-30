using System;

namespace ChatApp.Chat.Dtos
{
    public class AddGroupMemberDto
    {
        public Guid GroupId { get; set; }
        public Guid UserId { get; set; }
    }
}
