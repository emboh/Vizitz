using FluentValidation;
using System.ComponentModel.DataAnnotations;
using Vizitz.Entities;
using Vizitz.Models.Account;

namespace Vizitz.Validators
{
    public class RegisterValidator : AbstractValidator<RegisterDTO>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Password)
                .NotNull()
                .NotEmpty()
                .MinimumLength(6);

            RuleFor(x => x.Identification)
                .NotNull()
                .NotEmpty()
                .Length(16);

            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(255);

            RuleFor(x => x.Address).MaximumLength(255);

            RuleFor(x => x.PhoneNumber)
                .NotNull()
                .NotEmpty()
                .Must(x =>
                {
                    return new PhoneAttribute().IsValid(x);
                });

            RuleFor(x => x.Roles)
                .Must(x => x.Contains(Role.Proprietor) || x.Contains(Role.Visitor));
        }
    }
}
