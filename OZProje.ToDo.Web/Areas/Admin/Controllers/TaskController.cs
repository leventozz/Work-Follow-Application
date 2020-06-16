using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OZProje.ToDo.Business.Interfaces;
using OZProje.ToDo.Entities.Concrete;
using OZProje.ToDo.Web.Areas.Admin.Models;

namespace OZProje.ToDo.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;
        private readonly IPriorityService _priorityService;
        public TaskController(ITaskService taskService, IPriorityService priorityService)
        {
            _taskService = taskService;
            _priorityService = priorityService;
        }
        public IActionResult Index()
        {
            TempData["Active"] = "task";
            List<Task> tasks = _taskService.GetAll();
            List<TaskListViewModel> models = new List<TaskListViewModel>();
            foreach (var item in tasks)
            {
                TaskListViewModel model = new TaskListViewModel
                {
                    Description = item.Description,
                    CreatedOn = item.CreatedOn,
                    Id = item.Id,
                    IsComplete = item.IsComplete,
                    Name = item.Name,
                    Priority = item.Priority,
                    PriorityId = item.PriorityId
                };
                models.Add(model);
            }
            return View(models);
        }
        public IActionResult AddTask()
        {
            TempData["Active"] = "task";
            ViewBag.PriorityList = new SelectList(_priorityService.GetAll(),"Id", "Definition");
            return View(new TaskAddViewModel());
        }
        [HttpPost]
        public IActionResult AddTask(TaskAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                _taskService.Save(new Task
                {
                    Name = model.Name,
                    Description = model.Description,
                    PriorityId = model.PriorityId
                });
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
