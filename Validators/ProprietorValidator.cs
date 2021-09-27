using FluentValidation;
using System.ComponentModel.DataAnnotations;
using Vizitz.Entities;
using Vizitz.Models;

namespace Vizitz.Validators
{
    public class CreateProprietorValidator : AbstractValidator<CreateProprietorDTO>
    {
        public CreateProprietorValidator()
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

            RuleFor(x => x.Address)
                .MaximumLength(255);

            RuleFor(x => x.PhoneNumber)
                .NotNull()
                .NotEmpty()
                .Must(x =>
                {
                    return new PhoneAttribute().IsValid(x);
                });
        }
    }

    public class UpdateProprietorValidator : AbstractValidator<UpdateProprietorDTO>
    {
        public UpdateProprietorValidator()
        {
            RuleFor(x => x.Email)
                .EmailAddress();

            RuleFor(x => x.Password)
                .MinimumLength(6);

            RuleFor(x => x.Identification)
                .Length(16);

            RuleFor(x => x.Name)
                .MaximumLength(255);

            RuleFor(x => x.Address)
                .MaximumLength(255);

            RuleFor(x => x.PhoneNumber)
                .Must(x =>
                {
                    return new PhoneAttribute().IsValid(x);
                });

            RuleFor(x => x.IsActive)
                .Must(x => x == null || x == false || x == true);

            RuleFor(x => x.Roles)
                .Must(x => x.Contains(Role.Proprietor) || x.Contains(Role.Visitor));
        }
    }
}
