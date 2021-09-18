using FluentValidation;
using Vizitz.Models;

namespace Vizitz.Validators
{
    public class UserValidator : AbstractValidator<UserDTO>
    {
        public UserValidator()
        {

        }
    }

    public class CreateUserValidator : AbstractValidator<CreateUserDTO>
    {
        public CreateUserValidator()
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
                .Length(16);

            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(255);

            RuleFor(x => x.Address)
                .MaximumLength(255);

            RuleFor(x => x.IsActive)
                .Must(x => x == null || x == false || x == true);
        }
    }

    public class UpdateUserValidator : AbstractValidator<UpdateUserDTO>
    {
        public UpdateUserValidator()
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
        }
    }
}
