using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OZProje.ToDo.Web.Models
{
    public class AppUserAddViewModel
    {
        [Required(ErrorMessage ="Kullanıcı adı boş bırakılamaz")]
        [Display(Name ="Kullanıcı Adı :")]
        public string UserName { get; set; }

        [Display(Name = "Parola :")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Parola boş bırakılamaz")]
        public string Password { get; set; }

        [Display(Name = "Parola Tekrar :")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Girdiğiniz parolalar eşleşmemektedir")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "E-Mail :")]
        [EmailAddress(ErrorMessage ="Geçersiz mail adresi")]
        [Required(ErrorMessage = "E-mail boş bırakılamaz")]
        public string Email { get; set; }

        [Display(Name = "Ad :")]
        [Required(ErrorMessage = "Ad boş bırakılamaz")]
        public string Name { get; set; }

        [Display(Name = "Soyad :")]
        [Required(ErrorMessage = "Soyad boş bırakılamaz")]
        public string Surname { get; set; }
    }
}
