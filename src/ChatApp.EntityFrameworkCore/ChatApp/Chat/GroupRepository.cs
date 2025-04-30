using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatApp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;




namespace ChatApp.Chat
{
    public class GroupRepository 
        : EfCoreRepository<ChatAppDbContext, Group, Guid>, IGroupRepository
    {
        public GroupRepository(IDbContextProvider<ChatAppDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        // Your custom methods (optional)
    }

}