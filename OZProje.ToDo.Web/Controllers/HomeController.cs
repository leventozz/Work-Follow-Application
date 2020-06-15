using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OZProje.ToDo.Business.Interfaces;

namespace OZProje.ToDo.Web.Controllers
{
    public class HomeController : Controller
    {
        ITaskService _taskService;
        public HomeController(ITaskService taskService)
        {
            _taskService = taskService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
