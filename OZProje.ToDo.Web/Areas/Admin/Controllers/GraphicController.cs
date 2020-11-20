using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OZProje.ToDo.Business.Interfaces;
using OZProje.ToDo.Web.StringInfo;

namespace OZProje.ToDo.Web.Areas.Admin.Controllers
{
    [Area(AreaInfo.Admin)]
    [Authorize(Roles = RoleInfo.Admin)]
    public class GraphicController : Controller
    {
        private readonly IAppUserService _appUserService;
        public GraphicController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }
        public IActionResult Index()
        {
            TempData["Active"] = TempdataInfo.Graphics;
            return View();
        }
        public IActionResult GetTopTaskCompletionPersonnels()
        {
            var jsonString = JsonConvert.SerializeObject(_appUserService.GetTopTaskCompletionPersonnels());
            return Json(jsonString);
        }

        public IActionResult GetTopActivePersonnels()
        {
            var jsonString = JsonConvert.SerializeObject(_appUserService.GetTopActivePersonnels());
            return Json(jsonString);
        }
    }
}
