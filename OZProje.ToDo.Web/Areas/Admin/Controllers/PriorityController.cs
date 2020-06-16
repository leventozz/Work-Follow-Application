using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OZProje.ToDo.Business.Interfaces;
using OZProje.ToDo.Entities.Concrete;
using OZProje.ToDo.Web.Areas.Admin.Models;

namespace OZProje.ToDo.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PriorityController : Controller
    {
        private readonly IPriorityService _priorityService;
        public PriorityController(IPriorityService priorityService)
        {
            _priorityService = priorityService;
        }
        public IActionResult Index()
        {
            TempData["Active"] = "priority";
            List<Priority> priorities = _priorityService.GetAll();
            List<PriorityListViewModel> model = new List<PriorityListViewModel>();
            foreach (var item in priorities)
            {
                PriorityListViewModel priorityListViewModel = new PriorityListViewModel();
                priorityListViewModel.Id = item.Id;
                priorityListViewModel.Definition = item.Definition;

                model.Add(priorityListViewModel);
            }

            return View(model);
        }
        public IActionResult AddPriority()
        {
            return View(new PriorityAddViewModel());
        }

        [HttpPost]
        public IActionResult AddPriority(PriorityAddViewModel model)
        {
            if (ModelState.IsValid) 
            {
                _priorityService.Save(new Priority()
                { 
                    Definition = model.Defination,
                });
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult UpdatePriority(int id)
        {
            TempData["Active"] = "priority";
            var priority = _priorityService.GetById(id);
            PriorityUpdateViewModel model = new PriorityUpdateViewModel
            {
                Id = priority.Id,
                Defination = priority.Definition
            };
            return View(model);        
        }
        [HttpPost]
        public IActionResult UpdatePriority(PriorityUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                _priorityService.Update(new Priority
                {
                    Id = model.Id,
                    Definition = model.Defination
                });
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
