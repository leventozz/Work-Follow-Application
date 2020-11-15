using OZProje.ToDo.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OZProje.ToDo.Entities.Concrete
{
    public class Notification : ITable
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public string Description { get; set; }
        public bool IsRead { get; set; }
    }
}
