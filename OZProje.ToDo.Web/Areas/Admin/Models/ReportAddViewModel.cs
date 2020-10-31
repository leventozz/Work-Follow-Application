using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OZProje.ToDo.Web.Areas.Admin.Models
{
    public class ReportAddViewModel
    {
        [Display(Name = "Başlık: ")]
        [Required(ErrorMessage ="Başlık alanı boş geçilemez")]
        public string Title { get; set; }
        [Display(Name = "Detay: ")]
        [Required(ErrorMessage = "Detay alanı boş geçilemez")]
        public string Description { get; set; }
        public int TaskId { get; set; }
    }
}
