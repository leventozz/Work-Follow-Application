using System;
using System.Collections.Generic;
using System.Text;

namespace OZProje.ToDo.DTO.DTOs.AppUserDTOs
{
    public class AppUserListDto
    {
        public int Id { get; set; }
        //[Required(ErrorMessage = "Ad alanı boş geçilemez")]
        //[Display(Name = "Ad: ")]
        public string Name { get; set; }
        //[Required(ErrorMessage = "Soyad alanı boş geçilemez")]
        //[Display(Name = "Soyad: ")]
        public string Surname { get; set; }
        //[Display(Name = "E-posta: ")]
        public string Email { get; set; }
        //[Display(Name = "Avatar: ")]
        public string Picture { get; set; }
    }
}
