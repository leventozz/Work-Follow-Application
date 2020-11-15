using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OZProje.ToDo.Business.Interfaces;
using OZProje.ToDo.Entities.Concrete;

namespace OZProje.ToDo.Web.Areas.Member.Controllers
{
    [Area("Member")]
    [Authorize(Roles = "Member")]
    public class HomeController : Controller
    {
        private readonly IReportService _reportService;
        private readonly UserManager<AppUser> _userManager;
        private readonly ITaskService _taskService;
        private readonly INotificationService _notificationService;
        public HomeController(IReportService reportService, UserManager<AppUser> userManager, ITaskService taskService, INotificationService notificationService)
        {
            _reportService = reportService;
            _userManager = userManager;
            _taskService = taskService;
            _notificationService = notificationService;
        }
        public async Task<IActionResult> Index()
        {
            TempData["Active"] = "home";
            var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.ReportCount = _reportService.GetReportsCount(currentUser.Id);
            ViewBag.CompletedTaskCount = _taskService.GetCompletedTaskCount(currentUser.Id);
            ViewBag.UnreadNotificationCount = _notificationService.GetUnread(currentUser.Id).Count();
            ViewBag.NotCompletedTaskCount = _taskService.GetNotCompletedTaskCount(currentUser.Id);
            return View();
        }
    }
}
