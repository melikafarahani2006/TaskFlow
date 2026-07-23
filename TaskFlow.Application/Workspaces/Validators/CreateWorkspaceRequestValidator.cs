using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using TaskFlow.Application.Workspaces.Dtos;

public class CreateWorkspaceRequestValidator
    : AbstractValidator<CreateWorkspaceRequest>
{
    public CreateWorkspaceRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100);
    }
}
