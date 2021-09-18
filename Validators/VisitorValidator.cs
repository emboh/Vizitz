using FluentValidation;
using System.ComponentModel.DataAnnotations;
using Vizitz.Entities;
using Vizitz.Models;

namespace Vizitz.Validators
{
    public class VisitorValidator : AbstractValidator<VisitorDTO>
    {
        public VisitorValidator()
        {

        }
    }

    public class CreateVisitorValidator : AbstractValidator<CreateVisitorDTO>
    {
        public CreateVisitorValidator()
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
        }
    }

    public class UpdateVisitorValidator : AbstractValidator<UpdateVisitorDTO>
    {
        public UpdateVisitorValidator()
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

            RuleFor(x => x.IsActive)
                .Must(x => x == null || x == false || x == true);

            RuleFor(x => x.PhoneNumber)
                .Must(x =>
                {
                    return new PhoneAttribute().IsValid(x);
                });

            RuleFor(x => x.Roles)
                .Must(x => x.Contains(Role.Proprietor) || x.Contains(Role.Visitor));
        }
    }
}
