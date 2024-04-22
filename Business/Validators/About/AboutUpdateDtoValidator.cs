using Business.DTOs.About.Request;
using FluentValidation;


namespace Business.Validators.About
{
    public class AboutUpdateDtoValidator : AbstractValidator<AboutUpdateDto>
    {
        public AboutUpdateDtoValidator()
        {
            RuleFor(x => x.Year)
            .NotEmpty()
            .WithMessage("Il daxil edilmelidir");


            RuleFor(x => x.Title)
            .MinimumLength(10)
            .WithMessage("Minimum 10 character daxil edin")
            .MaximumLength(50)
            .WithMessage("Maximum 50 character daxil edin")
            .NotEmpty()
            .WithMessage("Ad daxil edilmelidir");

            RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("Description daxil edilmelidir")
            .MaximumLength(1000)
            .WithMessage("max chracter sayi 20 olmalidir");

            RuleFor(x => x.ImageFile)
            .NotEmpty()
            .WithMessage("image daxil edilmelidir");


        }
    }
}
