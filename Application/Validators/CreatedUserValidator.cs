using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Application.UseCases.Command;
using Application.UseCases.Command.User;

namespace Application.Validators
{
    public class CreatedUserValidator: AbstractValidator<AddUserCommand>
    {
        public CreatedUserValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username is required");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required");
            RuleFor(x => x.Role)
                .NotEmpty().WithMessage("Role is required");
            RuleFor(x => x.Status)
                .NotEmpty().WithMessage("Status is required");
        }

    }
}
