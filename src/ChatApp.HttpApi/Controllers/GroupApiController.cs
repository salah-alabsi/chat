// using ChatApp.Chat.Dto;
// using Microsoft.AspNetCore.Mvc;
// using System;
// using System.Collections.Generic;
// using System.Threading.Tasks;
// // using ChatApp.ChatAppService;
//
// namespace ChatApp.HttpApi.Controllers
// {
//     [Route("api/groups")]
//     public class GroupApiController : ControllerBase
//     {
//         private readonly GroupAppService _groupAppService;
//
//         public GroupApiController(GroupAppService groupAppService)
//         {
//             _groupAppService = groupAppService;
//         }
//
//         [HttpPost]
//         public async Task<GroupDto> CreateAsync([FromBody] string name)
//         {
//             return await _groupAppService.CreateGroupAsync(name);
//         }
//
//         [HttpGet("my")]
//         public async Task<List<GroupDto>> GetMyGroupsAsync(Guid userId)
//         {
//             return await _groupAppService.GetMyGroupsAsync(userId);
//         }
//     }
// }
