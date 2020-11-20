using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using OZProje.ToDo.Business.Interfaces;
using OZProje.ToDo.DTO.DTOs.TaskDTOs;
using OZProje.ToDo.Entities.Concrete;
using OZProje.ToDo.Web.StringInfo;

namespace OZProje.ToDo.Web.Areas.Admin.Controllers
{
    [Area(AreaInfo.Admin)]
    [Authorize(Roles = RoleInfo.Admin)]
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;
        private readonly IPriorityService _priorityService;
        private readonly IMapper _mapper;
        public TaskController(ITaskService taskService, IPriorityService priorityService, IMapper mapper)
        {
            _taskService = taskService;
            _priorityService = priorityService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            TempData["Active"] = TempdataInfo.Task;
            var result =_mapper.Map<List<TaskListDto>>(_taskService.GetIsNotCompleted());
            return View(result);
        }
        public IActionResult AddTask()
        {
            TempData["Active"] = TempdataInfo.Task;
            ViewBag.PriorityList = new SelectList(_priorityService.GetAll(),"Id", "Definition");
            return View(new TaskAddDto());
        }
        [HttpPost]
        public IActionResult AddTask(TaskAddDto model)
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
        public IActionResult UpdateTask(int id)
        {
            TempData["Active"] = TempdataInfo.Task;
            var result = _mapper.Map<TaskUpdateDto>(_taskService.GetById(id));
            ViewBag.PriorityList = new SelectList(_priorityService.GetAll(), "Id", "Definition", result.PriorityId);
            return View(result);
        }
        [HttpPost]
        public IActionResult UpdateTask(TaskUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                _taskService.Update(new Task()
                {
                    Id = model.Id,
                    Description = model.Description,
                    Name = model.Name,
                    PriorityId = model.PriorityId
                });
                return RedirectToAction("Index");
            }
            ViewBag.PriorityList = new SelectList(_priorityService.GetAll(), "Id", "Definition", model.PriorityId);
            return View(model);
        }
        public IActionResult DeleteTask(int id)
        {
            _taskService.Delete(new Task() { Id=id });
            return Json(null);
        }
    }
}
