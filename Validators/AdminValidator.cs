using FluentValidation;
using Vizitz.Models;

namespace Vizitz.Validators
{
    public class CreateAdminValidator : AbstractValidator<CreateAdminDTO>
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

    public class UpdateAdminValidator : AbstractValidator<UpdateAdminDTO>
    {
        public UpdateAdminValidator()
        {
            RuleFor(x => x.Email)
                .EmailAddress();

            RuleFor(x => x.Password)
                .MinimumLength(6);

            RuleFor(x => x.Name)
                .MaximumLength(255);

            RuleFor(x => x.IsActive).Must(x => x == null || x == false || x == true);
        }
    }
}
