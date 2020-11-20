using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OZProje.ToDo.Business.Interfaces;
using OZProje.ToDo.DTO.DTOs.TaskDTOs;
using OZProje.ToDo.Entities.Concrete;
using OZProje.ToDo.Web.BaseControllers;
using OZProje.ToDo.Web.StringInfo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OZProje.ToDo.Web.Areas.Member.Controllers
{
    [Area(AreaInfo.Member)]
    [Authorize(Roles =RoleInfo.Member)]
    public class CompletedTasksController : BaseIdentityController
    {
        private readonly ITaskService _taskService;
        private readonly IMapper _mapper;
        public CompletedTasksController(ITaskService taskService, UserManager<AppUser> userManager, IMapper mapper) : base(userManager)
        {
            _taskService = taskService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index(int activeIndex=1)
        {
            TempData["Active"] = TempdataInfo.CompletedTasks;

            var user = await GetLoginedUser();
            var result = _mapper.Map<List<TaskListAllDto>>(_taskService.GetCompletedWithAllies(out int totalIndex, user.Id, activeIndex));

            ViewBag.TotalIndex = totalIndex;
            ViewBag.ActiveIndex = activeIndex;
 
            return View(result);
        }
    }
}
