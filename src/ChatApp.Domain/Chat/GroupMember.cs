using Volo.Abp.Domain.Entities;
using System;

namespace ChatApp.Chat
{
    public class GroupMember : Entity<Guid>
    {
        public Guid GroupId { get; set; }
        public Guid UserId { get; set; }

        private GroupMember() { }

        public GroupMember(Guid id, Guid groupId, Guid userId) : base(id)
        {
            GroupId = groupId;
            UserId = userId;
        }
    }
}
