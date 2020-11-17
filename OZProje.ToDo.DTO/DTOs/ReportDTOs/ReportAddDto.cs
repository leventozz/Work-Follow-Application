using System;
using System.Collections.Generic;
using System.Text;

namespace OZProje.ToDo.DTO.DTOs.ReportDTOs
{
    public class ReportAddDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int TaskId { get; set; }
        public Task Task { get; set; }
    }
}
