using FluentValidation;
using OZProje.ToDo.DTO.DTOs.AppUserDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace OZProje.ToDo.Business.ValidationRules.FluentValidation
{
    public class AppUserAddValidator : AbstractValidator<AppUserAddDto>
    {
        public AppUserAddValidator()
        {
            RuleFor(x => x.UserName).NotNull().WithMessage("Kullanıcı adı boş bırakılamaz");
            RuleFor(x => x.Password).NotNull().WithMessage("Parola boş bırakalamaz");
            RuleFor(x => x.ConfirmPassword).NotNull().WithMessage("Parola tekrarı boş bırakalamaz");
            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage("Parolalarınız eşleşmemektedir");
            RuleFor(x => x.Email).NotNull().WithMessage("Email boş bırakalamaz").EmailAddress().WithMessage("Lütfen geçerli bir email adresi giriniz");
            RuleFor(x => x.Name).NotNull().WithMessage("Ad alanı boş bırakılamaz");
            RuleFor(x => x.Surname).NotNull().WithMessage("Soyad alanı boş bırakılamaz");
        }
    }
}
