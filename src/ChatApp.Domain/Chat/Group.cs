using Volo.Abp.Domain.Entities;
using System;

namespace ChatApp.Chat
{
    public class Group : Entity<Guid>
    {
        public string Name { get; set; }

        private Group() { } // EF Core

        public Group(Guid id, string name) : base(id)
        {
            Name = name;
        }
    }
}
