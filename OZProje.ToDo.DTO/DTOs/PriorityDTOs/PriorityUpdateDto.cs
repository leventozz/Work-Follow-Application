using System;
using System.Collections.Generic;
using System.Text;

namespace OZProje.ToDo.DTO.DTOs.PriorityDTOs
{
    public class PriorityUpdateDto
    {
        //[Display(Name = "Tanım :")]
        //[Required(ErrorMessage = "Tanım alanı boş bırakılamaz")]
        public string Defination { get; set; }
        public int Id { get; set; }
    }
}

