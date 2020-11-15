using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<AppUser> _userManager;
        private readonly IFileService _fileService;

        public TaskOperationController(IAppUserService appUserService, ITaskService taskService, UserManager<AppUser> userManager, IFileService fileService)
        {
            _appUserService = appUserService;
            _taskService = taskService;
            _userManager = userManager;
            _fileService = fileService;
        }
        
        public IActionResult Index()
        {
            TempData["Active"] = "taskOperation";
            //var temp = _appUserService.GetMembers();

            var tasks =_taskService.GetWithAllies();
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

        public IActionResult AssignUserList(int id, string searchKey, int page=1)
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

        public IActionResult AssignUser(UserAssignViewModel model)
        {
            TempData["Active"] = "taskOperation";

            var user =_userManager.Users.FirstOrDefault(x => x.Id == model.AppUserId);
            var task = _taskService.GetByPriorityId(model.TaskId);

            AppUserListViewModel userModel = new AppUserListViewModel();
            userModel.Id = user.Id;
            userModel.Name = user.Name;
            userModel.Picture = user.Picture;
            userModel.Surname = user.Surname;
            userModel.Email = user.Email;

            TaskListViewModel taskModel = new TaskListViewModel();
            taskModel.Id = task.Id;
            taskModel.Description = task.Description;
            taskModel.Name = task.Name;
            taskModel.Priority = task.Priority;

            UserAssignListViewModel userAssignModel = new UserAssignListViewModel();
            userAssignModel.AppUser = userModel;
            userAssignModel.Task = taskModel;

            return View(userAssignModel);
        }

        [HttpPost]
        public IActionResult AssignUserList(UserAssignViewModel model)
        {
            var task = _taskService.GetById(model.TaskId);
            task.AppUserId = model.AppUserId;
            _taskService.Update(task);
            return RedirectToAction("Index");
        }

        public IActionResult ViewDetail(int id)
        {
            TempData["Active"] = "taskOperation";

            var task = _taskService.GetReportsById(id);
            TaskListAllViewModel model = new TaskListAllViewModel();
            model.Id = task.Id;
            model.Reports = task.Reports;
            model.Name = task.Name;
            model.Description = task.Description;
            model.AppUser = task.AppUser;
            return View(model);
        }

        public IActionResult ExcelExport(int id)
        {
            return File((_fileService.ExcelExport(_taskService.GetReportsById(id).Reports)), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",Guid.NewGuid()+".xlsx");
        }

        public IActionResult PDFExport(int id)
        {
            var path = _fileService.PdfExport(_taskService.GetReportsById(id).Reports);
            return File(path, "applicaiton/pdf", Guid.NewGuid() + ".pdf");
        }
    }
}
