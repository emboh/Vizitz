using FluentValidation;
using System;
using System.ComponentModel.DataAnnotations;
using Vizitz.Models;

namespace Vizitz.Validators
{
    public class VenueValidator : AbstractValidator<VenueDTO>
    {
        public VenueValidator()
        {

        }
    }

    public class CreateVenueValidator : AbstractValidator<CreateVenueDTO>
    {
        public CreateVenueValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(255);

            RuleFor(x => x.Address)
                .MaximumLength(255);

            RuleFor(x => x.Description)
                .MaximumLength(255);

            RuleFor(x => x.Phone)
                .Must(x =>
                {
                    return new PhoneAttribute().IsValid(x);
                });

            RuleFor(x => x.Latitude)
                .InclusiveBetween(-90, 90);

            RuleFor(x => x.Longitude)
                .InclusiveBetween(-180, 180);

            RuleFor(x => x.Rating)
                .InclusiveBetween(0, 5);

            RuleFor(x => x.IsActive)
                .Must(x => x == null || x == false || x == true);
        }
    }

    public class UpdateVenueValidator : AbstractValidator<UpdateVenueDTO>
    {
        public UpdateVenueValidator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(255);

            RuleFor(x => x.Address)
                .MaximumLength(255);

            RuleFor(x => x.Description)
                .MaximumLength(255);

            RuleFor(x => x.Phone)
                .Must(x =>
                {
                    return new PhoneAttribute().IsValid(x);
                });

            RuleFor(x => x.Latitude)
                .InclusiveBetween(-90, 90);

            RuleFor(x => x.Longitude)
                .InclusiveBetween(-180, 180);

            RuleFor(x => x.Rating)
                .InclusiveBetween(0, 5);

            RuleFor(x => x.IsActive)
                .Must(x => x == null || x == false || x == true);
        }
    }
}
