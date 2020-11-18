using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OZProje.ToDo.Business.Interfaces;
using OZProje.ToDo.DTO.DTOs.TaskDTOs;
using OZProje.ToDo.Entities.Concrete;
using OZProje.ToDo.Web.Areas.Admin.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OZProje.ToDo.Web.Areas.Member.Controllers
{
    [Authorize(Roles ="Member")]
    [Area("Member")]
    public class CompletedTasksController : Controller
    {
        private readonly ITaskService _taskService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        public CompletedTasksController(ITaskService taskService, UserManager<AppUser> userManager, IMapper mapper)
        {
            _taskService = taskService;
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index(int activeIndex=1)
        {
            TempData["Active"] = "completedTasks";

            int totalIndex;

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var result = _mapper.Map<List<TaskListAllDto>>(_taskService.GetCompletedWithAllies(out totalIndex, user.Id, activeIndex));

            ViewBag.TotalIndex = totalIndex;
            ViewBag.ActiveIndex = activeIndex;
 
            return View(result);
        }
    }
}
