using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OZProje.ToDo.Business.Interfaces;
using OZProje.ToDo.Entities.Concrete;
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

        public IActionResult AssignUser(int id, string searchKey, int page=1)
        {
            TempData["Active"] = "taskOperation";
            ViewBag.ActivePage = page;
            //ViewBag.TotalPage = (int)Math.Ceiling((double)_appUserService.GetMembers().Count /3);
            int totalPage; 

            var task = _taskService.GetByPriorityId(id);
            var users = _appUserService.GetMembers(out totalPage, searchKey, page);

            ViewBag.TotalPage = totalPage;
            ViewBag.Search = searchKey;
            var taskModel = new TaskListViewModel();

            List<AppUserListViewModel> userModels = new List<AppUserListViewModel>();

            foreach (var item in users)
            {
                var userModel = new AppUserListViewModel();
                userModel.Id = item.Id;
                userModel.Email = item.Email;
                userModel.Name = item.Name;
                userModel.Surname = item.Surname;
                userModel.Picture = item.Picture;
                userModels.Add(userModel);
            }

            ViewBag.Users = userModels;

            taskModel.Id = task.Id;
            taskModel.Description = task.Description;
            taskModel.CreatedOn = task.CreatedOn;
            taskModel.Name = task.Name;
            taskModel.Priority = task.Priority;
            return View(taskModel);
        }
    }
}
