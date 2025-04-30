using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ChatApp.Chat.Dto;

namespace ChatApp.Chat
{
    public interface IGroupAppService
    {
        Task<GroupDto> CreateGroupAsync(string name);
        Task AddMemberAsync(Guid groupId, Guid userId);
        Task<List<GroupDto>> GetMyGroupsAsync(Guid userId);
        Task<List<GroupDto>> GetAllGroupsAsync();
    }
}
