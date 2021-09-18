using FluentValidation;
using Vizitz.Models;

namespace Vizitz.Validators
{
    public class AdminValidator : FluentValidation.AbstractValidator<AdminDTO>
    {
        public AdminValidator()
        {

        }
    }

    public class CreateAdminValidator : FluentValidation.AbstractValidator<CreateAdminDTO>
    {
        public CreateAdminValidator()
        {
            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Password)
                .NotNull()
                .NotEmpty()
                .MinimumLength(6);

            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(255);

            RuleFor(x => x.IsActive).Must(x => x == null || x == false || x == true);
        }
    }
}
