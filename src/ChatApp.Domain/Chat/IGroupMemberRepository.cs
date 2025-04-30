using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace ChatApp.Chat
{
    public interface IGroupMemberRepository : IRepository<GroupMember, Guid>
    {
    }
}
