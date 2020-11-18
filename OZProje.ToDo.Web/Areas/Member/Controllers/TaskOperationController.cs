using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OZProje.ToDo.Business.Interfaces;
using OZProje.ToDo.DTO.DTOs.ReportDTOs;
using OZProje.ToDo.DTO.DTOs.TaskDTOs;
using OZProje.ToDo.Entities.Concrete;
using OZProje.ToDo.Web.Areas.Admin.Models;

namespace OZProje.ToDo.Web.Areas.Member.Controllers
{
    [Area("Member")]
    [Authorize(Roles = "Member")]
    public class TaskOperationController : Controller
    {
        private readonly IReportService _reportService;
        private readonly UserManager<AppUser> _userManager;
        private readonly ITaskService _taskService;
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;
        public TaskOperationController(ITaskService taskService, UserManager<AppUser> userManager, IReportService reportService, INotificationService notificationService, IMapper mapper)
        {
            _reportService = reportService;
            _taskService = taskService;
            _userManager = userManager;
            _notificationService = notificationService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            TempData["Active"] = "taskoperation";

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var result = _mapper.Map<List<TaskListAllDto>>(_taskService.GetWithAllies(x => x.AppUserId == user.Id && !x.IsComplete));
            return View(result);
        }
        public IActionResult AddReport(int id)
        {
            TempData["Active"] = "taskoperation";
            var task = _taskService.GetByPriorityId(id);
            ReportAddDto model = new ReportAddDto();
            model.TaskId = id;
            model.Task = task;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddReport(ReportAddDto model)
        {
            if (ModelState.IsValid)
            {
                _reportService.Save(new Report
                {
                    TaskId = model.TaskId,
                    Description = model.Description,
                    Title = model.Title
                });

                var adminList = await _userManager.GetUsersInRoleAsync("Admin");
                var activeUser = await _userManager.FindByNameAsync(User.Identity.Name);

                foreach (var admin in adminList)
                {
                    _notificationService.Save(new Notification
                    {
                        Description = string.Format("{0} {1} yeni bir rapor ekledi.", activeUser.Name, activeUser.Surname),
                        AppUserId = admin.Id
                    });
                }

                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult UpdateReport(int id)
        {
            TempData["Active"] = "taskoperation";
            var result = _mapper.Map<ReportUpdateDto>(_reportService.GetWithAllies(id));
            return View(result);
        }

        [HttpPost]
        public IActionResult UpdateReport(ReportUpdateDto model)
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

        public async Task<IActionResult> MarkAsCompleted(int taskId)
        {
            var currentTask = _taskService.GetById(taskId);
            currentTask.IsComplete = true;
            _taskService.Update(currentTask);

            var adminList = await _userManager.GetUsersInRoleAsync("Admin");
            var activeUser = await _userManager.FindByNameAsync(User.Identity.Name);

            foreach (var admin in adminList)
            {
                _notificationService.Save(new Notification
                {
                    Description = string.Format("{0} {1} bir görevi tamamladı.", activeUser.Name, activeUser.Surname),
                    AppUserId = admin.Id
                });
            }

            return Json(null);
        }
    }
}
