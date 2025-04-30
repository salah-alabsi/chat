using Microsoft.AspNetCore.Mvc;
using ChatApp.Chat.Dto;
using ChatApp.ChatAppService;
using System;
using System.Threading.Tasks;
using ChatApp.Chat;
using Volo.Abp.DependencyInjection;

namespace ChatApp.Web.Controllers
{
    public class GroupController : Controller
    {
        private readonly IGroupAppService _groupAppService;

        public GroupController(IGroupAppService groupAppService)
        {
            _groupAppService = groupAppService;
        }

        // Display all groups
        public async Task<IActionResult> Index()
        {
            var groups = await _groupAppService.GetAllGroupsAsync();
            return View(groups);
        }

        // Create a new group
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string name)
        {
            
            var groupDto = await _groupAppService.CreateGroupAsync(name);
            return RedirectToAction("Index");
        }

        // Display group details
        // public async Task<IActionResult> Details(Guid groupId)
        // {
        //     var group = await _groupAppService.GetAllGroupsAsync();
        //     return View(group);
        // }
    }
}
