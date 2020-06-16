using OZProje.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OZProje.ToDo.Web.Areas.Admin.Models
{
    public class TaskListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsComplete { get; set; }
        public int PriorityId { get; set; }
        public Priority Priority { get; set; }
    }
}
