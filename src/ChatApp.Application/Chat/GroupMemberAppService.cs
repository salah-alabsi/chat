using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatApp.Chat;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

public class GroupMemberAppService :ApplicationService, IGroupMemberAppService
{
    private readonly IRepository<GroupMember, Guid> _groupMemberRepository;

    public GroupMemberAppService(IRepository<GroupMember, Guid> groupMemberRepository)
    {
        _groupMemberRepository = groupMemberRepository;
    }

    public async Task<List<Guid>> GetGroupIdsForUserAsync(Guid userId)
    {
        var groupMembers = await _groupMemberRepository.GetListAsync(x => x.UserId == userId);
        return groupMembers.Select(x => x.GroupId).ToList();
    }
}
