using FluentValidation;
using OZProje.ToDo.DTO.DTOs.AppUserDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace OZProje.ToDo.Business.ValidationRules.FluentValidation
{
    public class AppUserSignInValidator: AbstractValidator<AppUserSignInDto>
    {
        public AppUserSignInValidator()
        {
            RuleFor(x => x.UserName).NotNull().WithMessage("Kullanıcı adı boş bırakılamaz");
            RuleFor(x => x.Password).NotNull().WithMessage("Parola alanı boş bırakılamaz");
        }
    }
}
