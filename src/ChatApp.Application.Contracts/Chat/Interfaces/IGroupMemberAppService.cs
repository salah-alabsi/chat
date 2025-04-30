using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IGroupMemberAppService
{
    Task<List<Guid>> GetGroupIdsForUserAsync(Guid userId);
}
