using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TaskFlow.Application.Projects.Dtos;

public class CreateProjectRequestValidator
    : AbstractValidator<CreateProjectRequest>
{
    public CreateProjectRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100);
    }
}
