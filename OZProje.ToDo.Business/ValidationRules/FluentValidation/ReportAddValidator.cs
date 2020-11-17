using FluentValidation;
using OZProje.ToDo.DTO.DTOs.ReportDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace OZProje.ToDo.Business.ValidationRules.FluentValidation
{
    public class ReportAddValidator : AbstractValidator<ReportAddDto>
    {
        public ReportAddValidator()
        {
            RuleFor(x => x.Title).NotNull().WithMessage("Başlık alanı boş bırakılamaz");
            RuleFor(x => x.Description).NotNull().WithMessage("Detay alanı boş bırakılamaz");
        }
    }
}
