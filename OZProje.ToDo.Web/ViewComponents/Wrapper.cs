using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        public Wrapper(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
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

            var roles = _userManager.GetRolesAsync(user).Result;

            if (roles.Contains("Admin"))
                return View(model);
            else
                return View("Member", model);
        }
    }
}
