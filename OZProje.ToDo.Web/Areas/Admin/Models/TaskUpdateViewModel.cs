using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OZProje.ToDo.Web.Areas.Admin.Models
{
    public class TaskUpdateViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ad alanı boş bırakılamaz")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Lütfen bir önem sırası belirtiniz")]
        public int PriorityId { get; set; }
    }
}
