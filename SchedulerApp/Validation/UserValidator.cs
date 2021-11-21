using FluentValidation;
using SchedulerViewModels;
using SchedulerViewModels.CreateModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulerApp.Validation
{
    public class UserValidator : AbstractValidator<StudentCreateModel>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Username is required");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is required");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required");
        }
    }
}
