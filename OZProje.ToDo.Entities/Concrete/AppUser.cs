using Microsoft.AspNetCore.Identity;
using OZProje.ToDo.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OZProje.ToDo.Entities.Concrete
{
    public class AppUser : IdentityUser<int>, ITable
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Picture { get; set; } = "default.png";
        public List<Task> Tasks { get; set; }
        public List<Notification> Notifications { get; set; }
    }
}
