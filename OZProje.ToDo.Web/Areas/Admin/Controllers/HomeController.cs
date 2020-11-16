using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OZProje.ToDo.Business.Interfaces;
using OZProje.ToDo.Entities.Concrete;

namespace OZProje.ToDo.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        private readonly ITaskService _taskService;
        private readonly INotificationService _notificationService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IReportService _reportService;
        public HomeController(ITaskService taskService, INotificationService notificationService, UserManager<AppUser> userManager, IReportService reportService)
        {
            _taskService = taskService;
            _notificationService = notificationService;
            _userManager = userManager;
            _reportService = reportService;
        }
        public async Task<IActionResult> Index()
        {
            TempData["Active"] = "home";
            var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.NotAssignedTaskCount = _taskService.GetNotAssignedTaskCount();
            ViewBag.AllCompletedTaskCount = _taskService.GetAllCompletedTaskCount();
            ViewBag.UnreadNotificationCount = _notificationService.GetUnread(currentUser.Id).Count();
            ViewBag.AllReportCount = _reportService.GetAllReportsCount();
            return View();
        }
    }
}
