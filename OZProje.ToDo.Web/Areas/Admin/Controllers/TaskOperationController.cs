using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OZProje.ToDo.Business.Interfaces;
using OZProje.ToDo.DTO.DTOs.AppUserDTOs;
using OZProje.ToDo.DTO.DTOs.TaskDTOs;
using OZProje.ToDo.Entities.Concrete;

namespace OZProje.ToDo.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class TaskOperationController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly ITaskService _taskService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IFileService _fileService;
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;
        public TaskOperationController(IAppUserService appUserService, ITaskService taskService, UserManager<AppUser> userManager, IFileService fileService, INotificationService notificationService, IMapper mapper)
        {
            _appUserService = appUserService;
            _taskService = taskService;
            _userManager = userManager;
            _fileService = fileService;
            _notificationService = notificationService;
            _mapper = mapper;
        }
        
        public IActionResult Index()
        {
            TempData["Active"] = "taskOperation";
            var result = _mapper.Map<List<TaskListAllDto>>(_taskService.GetWithAllies());
            return View(result);
        }

        public IActionResult AssignUserList(int id, string searchKey, int page=1)
        {
            TempData["Active"] = "taskOperation";
            ViewBag.ActivePage = page;

            var users = _mapper.Map<List<AppUserListDto>>(_appUserService.GetMembers(out int totalPage, searchKey, page));

            ViewBag.TotalPage = totalPage;
            ViewBag.Search = searchKey;
            ViewBag.Users = users;

            var task = _mapper.Map<TaskListDto>(_taskService.GetByPriorityId(id));
            return View(task);
        }

        public IActionResult AssignUser(UserAssignDto model)
        {
            TempData["Active"] = "taskOperation";

            var userResult = _mapper.Map<AppUserListDto>(_userManager.Users.FirstOrDefault(x => x.Id == model.AppUserId));
            var taskResult = _mapper.Map<TaskListDto>(_taskService.GetByPriorityId(model.TaskId));

            UserAssignListDto userAssignModel = new UserAssignListDto
            {
                AppUser = userResult,
                Task = taskResult
            };

            return View(userAssignModel);
        }

        [HttpPost]
        public IActionResult AssignUserList(UserAssignDto model)
        {
            var task = _taskService.GetById(model.TaskId);
            task.AppUserId = model.AppUserId;
            _taskService.Update(task);
            _notificationService.Save(new Notification
            {
                AppUserId = model.AppUserId,
                Description = string.Format("{0} işi için görevlendirildiniz.",task.Name)
            }) ;
            return RedirectToAction("Index");
        }

        public IActionResult ViewDetail(int id)
        {
            TempData["Active"] = "taskOperation";
            var result = _mapper.Map<TaskListAllDto>(_taskService.GetReportsById(id));
            return View(result);
        }

        public IActionResult ExcelExport(int id)
        {
            return File((_fileService.ExcelExport(_taskService.GetReportsById(id).Reports)), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",Guid.NewGuid()+".xlsx");
        }

        public IActionResult PDFExport(int id)
        {
            var path = _fileService.PdfExport(_taskService.GetReportsById(id).Reports);
            return File(path, "applicaiton/pdf", Guid.NewGuid() + ".pdf");
        }
    }
}
