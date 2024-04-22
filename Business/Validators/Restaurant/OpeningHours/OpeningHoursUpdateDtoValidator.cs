using Business.DTOs.RestaurantLocations.OpeningHours.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validators.Restaurant.OpeningHours
{
    public class OpeningHoursUpdateDtoValidator :AbstractValidator<OpeningHoursUpdateDto>
    {
        public OpeningHoursUpdateDtoValidator()
        {

            RuleFor(x => x.DayOfWeek)
        .NotEmpty().WithMessage("heftenin gunu daxil edilmelidir")
        .IsInEnum().WithMessage("enum tip olmalidir");


            RuleFor(x => x.OpeningTime)
              .NotEmpty()
              .WithMessage("Acilis time daxil edilmelidir");


            RuleFor(x => x.ClosingTime)
              .NotEmpty()
              .WithMessage("Baglanis time daxil edilmelidir");


    
        }
    }
}
