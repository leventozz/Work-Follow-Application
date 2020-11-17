using System;
using System.Collections.Generic;
using System.Text;

namespace OZProje.ToDo.DTO.DTOs.TaskDTOs
{
    public class TaskAddDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int PriorityId { get; set; }
    }
}
