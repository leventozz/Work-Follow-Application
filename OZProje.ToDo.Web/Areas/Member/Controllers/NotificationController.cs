﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OZProje.ToDo.Business.Interfaces;
using OZProje.ToDo.DTO.DTOs.NotificationDTOs;
using OZProje.ToDo.Entities.Concrete;
using OZProje.ToDo.Web.BaseControllers;
using OZProje.ToDo.Web.StringInfo;

namespace OZProje.ToDo.Web.Areas.Member.Controllers
{
    [Area(AreaInfo.Member)]
    [Authorize(Roles = RoleInfo.Member)]
    public class NotificationController : BaseIdentityController
    {
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;
        public NotificationController(INotificationService notificationService, UserManager<AppUser> userManager, IMapper mapper) : base(userManager)
        {
            _notificationService = notificationService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            TempData["active"] = TempdataInfo.Notifications;
            var currentUser = await GetLoginedUser();
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
