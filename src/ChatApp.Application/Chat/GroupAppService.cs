using ChatApp.Chat.Dto;
using ChatApp.Chat;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;


namespace ChatApp.ChatAppService
{
    public class GroupAppService : ApplicationService, IGroupAppService
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IGroupMemberRepository _groupMemberRepository;
        private readonly IMapper _mapper;

      
        public GroupAppService(IGroupRepository groupRepository, IGroupMemberRepository groupMemberRepository, IMapper mapper)
        {
            _groupRepository = groupRepository;
            _groupMemberRepository = groupMemberRepository;
            _mapper = mapper;
        }

        public async Task<GroupDto> CreateGroupAsync(string name)
        {
           
            
            var group = new Group(GuidGenerator.Create(), name);
           
            await _groupRepository.InsertAsync(group);
            Console.WriteLine("step2");
            return _mapper.Map<GroupDto>(group);
        }

        public async Task AddMemberAsync(Guid groupId, Guid userId)
        {
            var member = new GroupMember(GuidGenerator.Create(), groupId, userId);
            await _groupMemberRepository.InsertAsync(member);
        }

        public async Task<List<GroupDto>> GetMyGroupsAsync(Guid userId)
        {
            var memberships = await _groupMemberRepository.GetListAsync(x => x.UserId == userId);
            var groupIds = memberships.Select(x => x.GroupId).ToList();
            var groups = await _groupRepository.GetListAsync(x => groupIds.Contains(x.Id));
            return _mapper.Map<List<GroupDto>>(groups);
        }

        public async Task<List<GroupDto>> GetAllGroupsAsync()
        {
            var groups = await _groupRepository.GetListAsync();
            return _mapper.Map<List<GroupDto>>(groups);
        }
    }
}
