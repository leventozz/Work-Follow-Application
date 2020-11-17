using FluentValidation;
using OZProje.ToDo.DTO.DTOs.PriorityDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace OZProje.ToDo.Business.ValidationRules.FluentValidation
{
    public class PriorityAddValidator : AbstractValidator<PriorityAddDto>
    {
        public PriorityAddValidator()
        {
            RuleFor(x => x.Defination).NotNull().WithMessage("Tanım alanı boş geçilemez");
        }
    }
}
