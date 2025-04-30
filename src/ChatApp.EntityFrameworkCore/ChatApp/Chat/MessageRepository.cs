using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using ChatApp.EntityFrameworkCore;

namespace ChatApp.Chat
{
    public class MessageRepository : EfCoreRepository<ChatAppDbContext, Message, Guid>, IMessageRepository
    {
        public MessageRepository(IDbContextProvider<ChatAppDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<List<Message>> GetMessagesByGroupIdAsync(Guid groupId, int skipCount, int maxResultCount)
        {
            var dbContext = await GetDbContextAsync();
            return await dbContext.Messages
                .Where(m => m.GroupId == groupId)
                .OrderBy(m => m.CreationTime)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }

        public async Task<int> GetMessagesCountByGroupIdAsync(Guid groupId)
        {
            var dbContext = await GetDbContextAsync();
            return await dbContext.Messages
                .Where(m => m.GroupId == groupId)
                .CountAsync();
        }
    }
}
