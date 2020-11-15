using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OZProje.ToDo.Business.Interfaces;
using OZProje.ToDo.Entities.Concrete;
using OZProje.ToDo.Web.Areas.Admin.Models;

namespace OZProje.ToDo.Web.Areas.Member.Controllers
{
    [Area("Member")]
    [Authorize(Roles = "Member")]
    public class NotificationController : Controller
    {
        private readonly INotificationService _notificationService;
        private readonly UserManager<AppUser> _userManager;
        public NotificationController(INotificationService notificationService, UserManager<AppUser> userManager)
        {
            _notificationService = notificationService;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            TempData["active"] = "notifications";
            var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var notificationList = _notificationService.GetUnread(currentUser.Id);
            List<NotificationListViewModel> viewModels = new List<NotificationListViewModel>();
            foreach (var notification in notificationList)
            {
                NotificationListViewModel model = new NotificationListViewModel();
                model.Description = notification.Description;
                model.Id = notification.Id;
                viewModels.Add(model);
            }
            return View(viewModels);
        }

        [HttpPost]
        public IActionResult Index(int id)
        {
            var currentNotification = _notificationService.GetById(id);
            currentNotification.IsRead = true;
            _notificationService.Update(currentNotification);
            return RedirectToAction("Index");
        }
    }
}
