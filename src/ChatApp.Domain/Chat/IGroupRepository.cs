using Volo.Abp.Domain.Repositories;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ChatApp.Chat
{
    public interface IGroupRepository : IRepository<Group, Guid>
    {
        // Example custom method (optional now, useful later)

    }
}