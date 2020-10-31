using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OZProje.ToDo.Business.Interfaces;
using OZProje.ToDo.Entities.Concrete;
using OZProje.ToDo.Web.Areas.Admin.Models;

namespace OZProje.ToDo.Web.Areas.Member.Controllers
{
    [Area("Member")]
    public class TaskOperationController : Controller
    {
        private readonly IReportService _reportService;
        private readonly UserManager<AppUser> _userManager;
        private readonly ITaskService _taskService;
        public TaskOperationController(ITaskService taskService, UserManager<AppUser> userManager, IReportService reportService)
        {
            _reportService = reportService;
            _taskService = taskService;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            TempData["Active"] = "taskoperation";

            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var tasks = _taskService.GetWithAlias(x => x.AppUserId == user.Id && !x.IsComplete);
            List<TaskListAllViewModel> models = new List<TaskListAllViewModel>();

            foreach (var item in tasks)
            {
                TaskListAllViewModel model = new TaskListAllViewModel();
                model.Id = item.Id;
                model.Description = item.Description;
                model.Priority = item.Priority;
                model.Name = item.Name;
                model.AppUser = item.AppUser;
                model.Reports = item.Reports;
                model.CreatedOn = item.CreatedOn;
                models.Add(model);
            }
            return View(models);
        }
        public IActionResult AddReport(int id)
        {
            ReportAddViewModel model = new ReportAddViewModel();
            model.TaskId = id;
            return View(model);
        }
    }
}
