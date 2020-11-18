using OZProje.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;

namespace OZProje.ToDo.DTO.DTOs.TaskDTOs
{
    public class TaskListAllDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public Priority Priority { get; set; }
        public AppUser AppUser { get; set; }
        public List<Report> Reports { get; set; }
    }
}
