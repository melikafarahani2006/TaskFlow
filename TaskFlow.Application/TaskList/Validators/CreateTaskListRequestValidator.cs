using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TaskFlow.Application.TaskLists.Dtos;

public class CreateTaskListRequestValidator
    : AbstractValidator<CreateTaskListRequest>
{
    public CreateTaskListRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100);
    }
}
