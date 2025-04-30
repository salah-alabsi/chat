using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace ChatApp.Chat
{
    public interface IMessageRepository : IRepository<Message, Guid>
    {
    }
}
