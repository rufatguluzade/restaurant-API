using Business.DTOs.SubMenu.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validators.SubMenu
{
    public class SubMenuCreateDtoValidator : AbstractValidator<SubMenuCreateDto>
    {
        public SubMenuCreateDtoValidator()
        {
            RuleFor(x => x.Name)
               .NotEmpty()
               .WithMessage("Ad daxil edilmelidir")
               .MaximumLength(500)
               .WithMessage("Max length 500")
;



            RuleFor(x => x.MenuId)
              .NotEmpty()
              .WithMessage("Menu Id daxil edilmelidir");
        }
    }
}
