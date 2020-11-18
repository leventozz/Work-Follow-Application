using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OZProje.ToDo.Business.Interfaces;
using OZProje.ToDo.DTO.DTOs.NotificationDTOs;
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
        private readonly IMapper _mapper;
        public NotificationController(INotificationService notificationService, UserManager<AppUser> userManager, IMapper mapper)
        {
            _notificationService = notificationService;
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            TempData["active"] = "notifications";
            var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var result = _mapper.Map<List<NotificationListDto>>(_notificationService.GetUnread(currentUser.Id));
            return View(result);
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
