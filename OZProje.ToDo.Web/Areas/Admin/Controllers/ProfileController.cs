using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OZProje.ToDo.DTO.DTOs.AppUserDTOs;
using OZProje.ToDo.Entities.Concrete;
using OZProje.ToDo.Web.BaseControllers;
using OZProje.ToDo.Web.StringInfo;

namespace OZProje.ToDo.Web.Areas.Admin.Controllers
{
    [Area(AreaInfo.Admin)]
    [Authorize(Roles = RoleInfo.Admin)]
    public class ProfileController : BaseIdentityController
    {
        private readonly IMapper _mapper;
        public ProfileController(UserManager<AppUser> userManager, IMapper mapper) : base(userManager)
        {
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            TempData["Active"] = TempdataInfo.Profile;
            var result = _mapper.Map<AppUserListDto>(await GetLoginedUser());
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Index(AppUserListDto model, IFormFile namePicture) 
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

                AddError(result.Errors);
            }
            return View(model);
        }
    }
}
