using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OZProje.ToDo.Business.Interfaces;
using OZProje.ToDo.DTO.DTOs.PriorityDTOs;
using OZProje.ToDo.Entities.Concrete;
using OZProje.ToDo.Web.Areas.Admin.Models;

namespace OZProje.ToDo.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class PriorityController : Controller
    {
        private readonly IPriorityService _priorityService;
        private readonly IMapper _mapper;
        public PriorityController(IPriorityService priorityService, IMapper mapper)
        {
            _priorityService = priorityService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            TempData["Active"] = "priority";
            return View(_mapper.Map<List<PriorityListDto>>(_priorityService.GetAll()));
        }

        public IActionResult AddPriority()
        {
            return View(new PriorityAddDto());
        }

        [HttpPost]
        public IActionResult AddPriority(PriorityAddDto model)
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

        public IActionResult UpdatePriority(int id)
        {
            TempData["Active"] = "priority";
            return View(_mapper.Map<PriorityUpdateDto>(_priorityService.GetById(id)));
        }

        [HttpPost]
        public IActionResult UpdatePriority(PriorityUpdateDto model)
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
