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
            TempData["Active"] = "taskoperation";

            var task = _taskService.GetByPriorityId(id);

            ReportAddViewModel model = new ReportAddViewModel();
            model.TaskId = id;
            model.Task = task;

            return View(model);
        }

        [HttpPost]
        public IActionResult AddReport(ReportAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                _reportService.Save(new Report
                {
                    TaskId = model.TaskId,
                    Description = model.Description,
                    Title = model.Title
                });
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult UpdateReport(int id)
        {
            TempData["Active"] = "taskoperation";

            var report = _reportService.GetWithAllies(id);
            ReportUpdateViewModel model = new ReportUpdateViewModel();
            model.Id = report.Id;
            model.Task = report.Task;
            model.Title = report.Title;
            model.Description = report.Description;
            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateReport(ReportUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var currentReport = _reportService.GetById(model.Id);
                currentReport.Title = model.Title;
                currentReport.Description = model.Description;
                _reportService.Update(currentReport);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult MarkAsCompleted(int taskId)
        {
            var currentTask = _taskService.GetById(taskId);
            currentTask.IsComplete = true;
            _taskService.Update(currentTask);
            return Json(null);
        }
    }
}
