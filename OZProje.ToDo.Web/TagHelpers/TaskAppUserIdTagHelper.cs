using Microsoft.AspNetCore.Razor.TagHelpers;
using OZProje.ToDo.Business.Interfaces;
using OZProje.ToDo.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace OZProje.ToDo.Web.TagHelpers
{
    [HtmlTargetElement("getTasksByAppUserId")]
    public class TaskAppUserIdTagHelper : TagHelper
    {
        private readonly ITaskService _taskService;
        public TaskAppUserIdTagHelper(ITaskService taskService)
        {
            _taskService = taskService;
        }
        public int AppUserId { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            List<Task> tasks = _taskService.GetByAppUserId(AppUserId);
            int completed = tasks.Where(x => x.IsComplete).Count();
            int notCompleted = tasks.Where(x => !x.IsComplete).Count();

            string htmlString = string.Format("<strong>Tamamladığı görev sayısı: {0}</strong><br><strong>Devam eden görev sayısı: {1}</strong>", completed,notCompleted);

            output.Content.SetHtmlContent(htmlString);
        }
    }
}
