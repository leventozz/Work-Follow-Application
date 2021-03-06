﻿using FluentValidation;
using OZProje.ToDo.DTO.DTOs.TaskDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace OZProje.ToDo.Business.ValidationRules.FluentValidation
{
    public class TaskUpdateValidator: AbstractValidator<TaskUpdateDto>
    {
        public TaskUpdateValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Ad alanı boş bırakılamaz");
            RuleFor(x => x.PriorityId).ExclusiveBetween(0, int.MaxValue).WithMessage("Lütfen bir önem sırası belirtiniz");
        }
    }
}
