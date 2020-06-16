using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OZProje.ToDo.Web.Areas.Admin.Models
{
    public class PriorityUpdateViewModel
    {
        
        public int Id { get; set; }
        [Display(Name ="Tanım :")]
        [Required(ErrorMessage = "Tanım alanı boş bırakılamaz")]
        public string Defination { get; set; }
    }
}
