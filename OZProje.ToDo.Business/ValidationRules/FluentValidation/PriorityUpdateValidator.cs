using FluentValidation;
using OZProje.ToDo.DTO.DTOs.PriorityDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace OZProje.ToDo.Business.ValidationRules.FluentValidation
{
    public class PriorityUpdateValidator : AbstractValidator<PriorityUpdateDto>
    {
        public PriorityUpdateValidator()
        {
            RuleFor(x => x.Defination).NotNull().WithMessage("Aciliyet tanımı boş olamaz");
        }
    }
}
