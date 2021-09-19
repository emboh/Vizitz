using FluentValidation;
using Vizitz.Models.Account;

namespace Vizitz.Validators
{
    public class ChangePasswordValidator : AbstractValidator<ChangePasswordDTO>
    {
        public ChangePasswordValidator()
        {
            RuleFor(x => x.CurrentPassword)
                .NotNull()
                .NotEmpty()
                .MinimumLength(6);

            RuleFor(x => x.NewPassword)
                .NotNull()
                .NotEmpty()
                .NotEqual(x =>  x.CurrentPassword)
                .MinimumLength(6);
        }
    }
}
