using OZProje.ToDo.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OZProje.ToDo.Entities.Concrete
{
    public class Task :ITable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public bool IsComplete { get; set; }
        public int PriorityId { get; set; }
        public Priority Priority{ get; set; }

        public AppUser AppUser { get; set; }
        public int? AppUserId { get; set; }

        public List<Report> Reports{ get; set; }
    }
}
