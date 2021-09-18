using FluentValidation;
using System;
using Vizitz.Models;

namespace Vizitz.Validators
{
    public class VisitValidator : AbstractValidator<VisitDTO>
    {
        public VisitValidator()
        {

        }
    }

    public class CreateVisitValidator : AbstractValidator<CreateVisitDTO>
    {
        public CreateVisitValidator()
        {
            RuleFor(x => x.StartedAt)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.FinishedAt)
                .NotNull()
                .NotEmpty()
                .GreaterThan(x => x.StartedAt);

            RuleFor(x => x.Note).MaximumLength(255);

            RuleFor(x => x.Rate)
                .InclusiveBetween(0, 5);

            RuleFor(x => x.IsValid)
                .Must(x => x == null || x == false || x == true);

            RuleFor(x => x.ScheduleId)
                .NotNull()
                .NotEmpty()
                .Must(x => Guid.TryParse(x, out _));

            RuleFor(x => x.VisitorId)
                .NotNull()
                .NotEmpty()
                .Must(x => Guid.TryParse(x, out _));
        }
    }

    public class UpdateVisitValidator : AbstractValidator<UpdateVisitDTO>
    {
        public UpdateVisitValidator()
        {
            RuleFor(x => x.FinishedAt)
                .GreaterThan(x => x.StartedAt);

            RuleFor(x => x.Note).MaximumLength(255);

            RuleFor(x => x.Rate)
                .InclusiveBetween(0, 5);

            RuleFor(x => x.IsValid)
                .Must(x => x == null || x == false || x == true);

            RuleFor(x => x.ScheduleId)
                .Must(x => Guid.TryParse(x, out _));

            RuleFor(x => x.VisitorId)
                .Must(x => Guid.TryParse(x, out _));
        }
    }
}
