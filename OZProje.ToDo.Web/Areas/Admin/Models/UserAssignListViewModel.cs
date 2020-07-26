using OZProje.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OZProje.ToDo.Web.Areas.Admin.Models
{
    public class UserAssignListViewModel
    {
        public AppUserListViewModel AppUser { get; set; }
        public TaskListViewModel Task { get; set; }
    }
}
