using Business.DTOs.Product.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validators.Product
{
    public class ProductUpdateDtoValidator : AbstractValidator<ProductUpdateDto>
    {
        public ProductUpdateDtoValidator()
        {
            RuleFor(x => x.Name)
              .NotEmpty()
              .WithMessage("Ad daxil edilmelidir")
              .MaximumLength(500)
              .WithMessage("max chracter sayi 500 olmalidir");

            RuleFor(x => x.Price)
              .NotEmpty()
              .WithMessage("Price daxil edilmelidir");

            RuleFor(x => x.Composition)
              .NotEmpty()
              .WithMessage("Composition daxil edilmelidir");


            RuleFor(x => x.SubMenuId)
              .NotEmpty()
              .WithMessage("SubMenuId daxil edilmelidir");
        }
    }
}
