using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OZProje.ToDo.Business.Interfaces;
using OZProje.ToDo.Entities.Concrete;
using OZProje.ToDo.Web.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OZProje.ToDo.Web.ViewComponents
{
    public class Wrapper : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly INotificationService _notificationService;
        public Wrapper(UserManager<AppUser> userManager, INotificationService notificationService)
        {
            _userManager = userManager;
            _notificationService = notificationService;
        }

        public IViewComponentResult Invoke()
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            AppUserListViewModel model = new AppUserListViewModel();

            model.Id = user.Id;
            model.Name = user.Name;
            model.Picture = user.Picture;
            model.Surname = user.Surname;
            model.Email = user.Email;

            var notifications = _notificationService.GetUnread(user.Id).Count();
            ViewBag.NotificationCount = notifications;

            var roles = _userManager.GetRolesAsync(user).Result;

            if (roles.Contains("Admin"))
                return View(model);
            else
                return View("Member", model);
        }
    }
}
