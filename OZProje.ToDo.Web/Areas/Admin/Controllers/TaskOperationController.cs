using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OZProje.ToDo.Business.Interfaces;

namespace OZProje.ToDo.Web.Areas.Admin.Controllers
{
    public class TaskOperationController : Controller
    {
        IAppUserService _appUserService;
        public TaskOperationController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }
        [Area("Admin")]
        public IActionResult Index()
        {
            TempData["Active"] = "taskOperation";
            var temp = _appUserService.GetMembers();
            return View();
        }
    }
}
