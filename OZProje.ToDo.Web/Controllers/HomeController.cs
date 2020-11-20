using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OZProje.ToDo.Business.Interfaces;
using OZProje.ToDo.DTO.DTOs.AppUserDTOs;
using OZProje.ToDo.Entities.Concrete;
using OZProje.ToDo.Web.BaseControllers;

namespace OZProje.ToDo.Web.Controllers
{
    public class HomeController : BaseIdentityController
    {
        private readonly SignInManager<AppUser> _signInManager;
        public HomeController( UserManager<AppUser> userManager, SignInManager<AppUser> signInManager) : base(userManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<IActionResult> SignUp(AppUserAddDto model)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    Name = model.Name,
                    Surname = model.Surname
                };

                var result = await _userManager.CreateAsync(appUser, model.Password);

                if (result.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(appUser, "Member");

                    if (roleResult.Succeeded)
                        return RedirectToAction("Index");

                    AddError(result.Errors);
                }
                AddError(result.Errors);
            }
            return View();
        }

        public async System.Threading.Tasks.Task<IActionResult> SignIn(AppUserSignInDto model)
        {
            if (ModelState.IsValid)
            {
                var user = await GetLoginedUser();
                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(model.UserName,model.Password,model.RememberMe,false);
                    if (result.Succeeded)
                    {
                       var roles = await _userManager.GetRolesAsync(user);
                        if (roles.Contains("Admin"))
                        {
                            return RedirectToAction("Index","Home", new { area="Admin" });
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home", new { area = "Member" });
                        }
                    }
                }
                ModelState.AddModelError("Password", "Kullanıcı adı veya şifre hatalı");
            }
            return View("Index", model);
        }

        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}
