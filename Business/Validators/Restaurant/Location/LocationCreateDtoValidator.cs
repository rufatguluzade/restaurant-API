

using Business.DTOs.RestaurantLocations.Location.Request;
using FluentValidation;

namespace Business.Validators.Restaurant.Location
{
    public class LocationCreateDtoValidator :AbstractValidator<LocationCreateDto>
    {
        public LocationCreateDtoValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("name daxil edilmelidir")
            .MaximumLength(20)
            .WithMessage("name max 20 karakterden ibaret olmalidir");

          

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("info daxil edilmelidir")
                .MaximumLength(1000)
                .WithMessage("name max 1000 karakterden ibaret olmalidir");


            RuleFor(x => x.Location)
                .NotEmpty()
                .WithMessage("location daxil edilmelidir");

            RuleFor(x => x.OpeningHoursId)
                .NotEmpty()
                .WithMessage("position daxil edilmelidir");


            RuleFor(x => x.Phone)
               .NotEmpty()
               .WithMessage("email daxil edilmelidir")
               .MaximumLength(50)
               .WithMessage("max 20 xarakter ola biler");

            RuleFor(x => x.Email)
                 .NotEmpty()
                 .WithMessage("email daxil edilmelidir")
                 .EmailAddress()
                 .WithMessage("tip email olmalidir")
                 .MaximumLength(50)
                 .WithMessage("max 50 xarakter ola biler");


            RuleFor(x => x.OpeningHoursId)
      .NotEmpty()
      .WithMessage("OpeningHoursId daxil edilmelidir");
        }
    }
}
