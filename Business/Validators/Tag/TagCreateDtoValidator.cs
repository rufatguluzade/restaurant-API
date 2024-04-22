using Business.DTOs.Tag.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validators.Tag
{
    public class TagCreateDtoValidator :AbstractValidator<TagCreateDto>
    {
        public TagCreateDtoValidator()
        {
            RuleFor(x => x.Name)
           .MinimumLength(5)
           .WithMessage("Minimum 3 character daxil edin")
           .MaximumLength(50)
           .WithMessage("Maximum 15 character daxil edin")
           .NotEmpty()
           .WithMessage("Ad daxil edilmelidir");
        }
    }
}
