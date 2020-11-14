using OZProje.ToDo.Entities.Concrete;
using System.ComponentModel.DataAnnotations;

namespace OZProje.ToDo.Web.Areas.Admin.Models
{
    public class ReportUpdateViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Başlık: ")]
        [Required(ErrorMessage = "Başlık alanı boş geçilemez")]
        public string Title { get; set; }
        [Display(Name = "Detay: ")]
        [Required(ErrorMessage = "Detay alanı boş geçilemez")]
        public string Description { get; set; }
        public int TaskId { get; set; }
        public Task Task { get; set; }
    }
}
