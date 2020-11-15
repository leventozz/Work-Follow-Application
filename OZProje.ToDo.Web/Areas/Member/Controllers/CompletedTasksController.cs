using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OZProje.ToDo.Business.Interfaces;
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
        public CompletedTasksController(ITaskService taskService, UserManager<AppUser> userManager)
        {
            _taskService = taskService;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index(int activeIndex=1)
        {
            TempData["Active"] = "completedTasks";

            int totalIndex;
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var completedTaskList = _taskService.GetCompletedWithAllies(out totalIndex,user.Id,activeIndex);

            ViewBag.TotalIndex = totalIndex;
            ViewBag.ActiveIndex = activeIndex;

            List<TaskListAllViewModel> models = new List<TaskListAllViewModel>();

            foreach (var task in completedTaskList)
            {
                TaskListAllViewModel model = new TaskListAllViewModel();
                model.Id = task.Id;
                model.Description = task.Description;
                model.Priority = task.Priority;
                model.Name = task.Name;
                model.AppUser = task.AppUser;
                model.CreatedOn = task.CreatedOn;
                model.Reports = task.Reports;
                models.Add(model);
            }
 
            return View(models);
        }
    }
}
