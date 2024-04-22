using Business.DTOs.Blog.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validators.Blog
{
    public class BlogUpdateDtoValidator :AbstractValidator<BlogUpdateDto>
    {
        public BlogUpdateDtoValidator()
        {
            RuleFor(x => x.Title1)
                   .NotEmpty()
                   .WithMessage("Ad daxil edilmelidir")
                   .MaximumLength(20)
                   .WithMessage("max chracter sayi 20 olmalidir");



            RuleFor(x => x.Description1)
              .NotEmpty()
              .WithMessage("Description daxil edilmelidir")
               .MaximumLength(1000)
               .WithMessage("max chracter sayi 20 olmalidir");

            RuleFor(x => x.Title2)
                  .NotEmpty()
                  .WithMessage("Ad daxil edilmelidir")
                  .MaximumLength(20)
                  .WithMessage("max chracter sayi 20 olmalidir");



            RuleFor(x => x.Description2)
              .NotEmpty()
              .WithMessage("Description daxil edilmelidir")
               .MaximumLength(1000)
               .WithMessage("max chracter sayi 20 olmalidir");

            RuleFor(x => x.Author)
               .NotEmpty()
               .WithMessage("Author daxil edilmelidir")
               .MaximumLength(20)
               .WithMessage("max chracter sayi 20 olmalidir");



            RuleFor(x => x.BlogType)
             .IsInEnum()
             .WithMessage("Tip düzgün seçilməyib");


            RuleFor(x => x.ImageFile)
        .NotEmpty()
        .WithMessage("image daxil edilmelidir");

        }
    }
}
