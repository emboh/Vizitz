using FluentValidation;
using System;
using Vizitz.Models;

namespace Vizitz.Validators
{
    public class CreateScheduleValidator : AbstractValidator<CreateScheduleDTO>
    {
        public CreateScheduleValidator()
        {
            RuleFor(x => x.StartedAt)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.FinishedAt)
                .NotNull()
                .NotEmpty()
                .GreaterThan(x => x.StartedAt);

            RuleFor(x => x.Capacity)
                .NotNull()
                .NotEmpty()
                .InclusiveBetween(0, int.MaxValue);

            RuleFor(x => x.Note)
                .MaximumLength(255);

            RuleFor(x => x.IsValid)
                .Must(x => x == null || x == false || x == true);

            RuleFor(x => x.VenueId)
                .NotNull()
                .NotEmpty()
                .Must(x => Guid.TryParse(x, out _));
        }
    }

    public class UpdateScheduleValidator : AbstractValidator<UpdateScheduleDTO>
    {
        public UpdateScheduleValidator()
        {
            RuleFor(x => x.FinishedAt)
                .GreaterThan(x => x.StartedAt);

            RuleFor(x => x.Capacity)
                .InclusiveBetween(0, int.MaxValue);

            RuleFor(x => x.Note)
                .MaximumLength(255);

            RuleFor(x => x.IsValid)
                .Must(x => x == null || x == false || x == true);

            RuleFor(x => x.VenueId)
                .Must(x => Guid.TryParse(x, out _));
        }
    }
}
