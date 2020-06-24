using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OZProje.ToDo.Business.Interfaces;
using OZProje.ToDo.Web.Areas.Admin.Models;

namespace OZProje.ToDo.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class TaskOperationController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly ITaskService _taskService;
        public TaskOperationController(IAppUserService appUserService, ITaskService taskService)
        {
            _appUserService = appUserService;
            _taskService = taskService;
        }
        
        public IActionResult Index()
        {
            TempData["Active"] = "taskOperation";
            //var temp = _appUserService.GetMembers();

            var tasks =_taskService.GetWithAlias();
            List<TaskListAllViewModel> models = new List<TaskListAllViewModel>();
            foreach (var item in tasks)
            {
                TaskListAllViewModel model = new TaskListAllViewModel();
                model.Id = item.Id;
                model.Description = item.Description;
                model.Priority = item.Priority;
                model.Name = item.Name;
                model.AppUser = item.AppUser;
                model.CreatedOn = item.CreatedOn;
                model.Reports = item.Reports;
                models.Add(model);
            }
            return View(models);
        }

        public IActionResult AssignUser(int id)
        {
            var model = _taskService.GetByPriorityId(id);
            var temp = new TaskListViewModel();
            temp.Id = model.Id;
            temp.Description = model.Description;
            temp.CreatedOn = model.CreatedOn;
            temp.Name = model.Name;
            temp.Priority = model.Priority;
            return View(temp);
        }
    }
}
