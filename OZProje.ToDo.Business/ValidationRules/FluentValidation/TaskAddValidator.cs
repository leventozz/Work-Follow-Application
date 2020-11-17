using FluentValidation;
using OZProje.ToDo.DTO.DTOs.TaskDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace OZProje.ToDo.Business.ValidationRules.FluentValidation
{
    public class TaskAddValidator : AbstractValidator<TaskAddDto>
    {
        public TaskAddValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Ad alanı boş bırakılamaz");
            RuleFor(x => x.PriorityId).ExclusiveBetween(1, int.MaxValue).WithMessage("Lütfen bir önem sırası belirtiniz");
        }
    }
}
