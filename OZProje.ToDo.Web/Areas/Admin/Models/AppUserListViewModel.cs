using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OZProje.ToDo.Web.Areas.Admin.Models
{
    public class AppUserListViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Ad alanı boş geçilemez")]
        [Display(Name="Ad: ")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Soyad alanı boş geçilemez")]
        [Display(Name="Soyad: ")]
        public string Surname { get; set; }
        [Display(Name="E-posta: ")]
        public string Email { get; set; }
        [Display(Name="Avatar: ")]
        public string Picture { get; set; }
    }
}
