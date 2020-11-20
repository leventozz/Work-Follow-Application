using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OZProje.ToDo.Business.Interfaces;
using OZProje.ToDo.Entities.Concrete;
using OZProje.ToDo.Web.BaseControllers;
using OZProje.ToDo.Web.StringInfo;

namespace OZProje.ToDo.Web.Areas.Member.Controllers
{
    [Area(AreaInfo.Member)]
    [Authorize(Roles = RoleInfo.Member)]
    public class HomeController : BaseIdentityController
    {
        private readonly IReportService _reportService;
        private readonly ITaskService _taskService;
        private readonly INotificationService _notificationService;
        public HomeController(IReportService reportService, UserManager<AppUser> userManager, ITaskService taskService, INotificationService notificationService) : base(userManager)
        {
            _reportService = reportService;
            _taskService = taskService;
            _notificationService = notificationService;
        }
        public async Task<IActionResult> Index()
        {
            TempData["Active"] = TempdataInfo.Home;
            var currentUser = await GetLoginedUser();
            ViewBag.ReportCount = _reportService.GetReportsCount(currentUser.Id);
            ViewBag.CompletedTaskCount = _taskService.GetCompletedTaskCount(currentUser.Id);
            ViewBag.UnreadNotificationCount = _notificationService.GetUnread(currentUser.Id).Count();
            ViewBag.NotCompletedTaskCount = _taskService.GetNotCompletedTaskCount(currentUser.Id);
            return View();
        }
    }
}
