using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OZProje.ToDo.Web.Areas.Admin.Models
{
    public class PriorityAddViewModel
    {
        [Display(Name ="Tanım")]
        [Required(ErrorMessage ="Tanım alanı boş geçilemez")]
        public string Defination { get; set; }
    }
}
