using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OZProje.ToDo.Entities.Concrete;
using OZProje.ToDo.Web.Areas.Admin.Models;

namespace OZProje.ToDo.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            TempData["Active"] = "profile";
            var appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            AppUserListViewModel model = new AppUserListViewModel();
            model.Id = appUser.Id;
            model.Name = appUser.Name;
            model.Surname = appUser.Surname;
            model.Picture = appUser.Picture;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Index(AppUserListViewModel model, IFormFile namePicture) 
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.Users.FirstOrDefault(x => x.Id == model.Id);
                if (namePicture != null)
                {
                    string extension = Path.GetExtension(namePicture.FileName);
                    string pictureName = Guid.NewGuid() + extension;
                    string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/" + pictureName);
                    using (var stream = new FileStream(filePath,FileMode.Create))
                    {
                        await namePicture.CopyToAsync(stream);
                    }
                    user.Picture = pictureName;
                }
                user.Name = model.Name;
                user.Surname = model.Surname;
                user.Email = model.Email;

                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    TempData["message"] = "Güncelleme işleminiz başarı ile gerçekleşti";
                    return RedirectToAction("Index");
                }

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, item.Description);
                }
                    
            }
            return View(model);
        }
    }
}
