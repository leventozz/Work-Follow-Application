using System;
using System.Collections.Generic;
using System.Text;

namespace OZProje.ToDo.DTO.DTOs.TaskDTOs
{
    public class TaskListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsComplete { get; set; }
        public int PriorityId { get; set; }
        //public Priority Priority { get; set; }
    }
}
