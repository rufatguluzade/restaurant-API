using Business.DTOs.Menu.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validators.Menu
{
    public class MenuUpdateDtoValidator :AbstractValidator<MenuUpdateDto>
    {
        public MenuUpdateDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name daxil edilmelidir");
        }
    }
}
