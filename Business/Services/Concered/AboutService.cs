

using AutoMapper;
using Business.DTOs.About.Request;
using Business.DTOs.About.Response;
using Business.DTOs.Common;
using Business.Exceptions;
using Business.Extensions;
using Business.Services.Abstraction;
using Business.Validators.About;
using Common.Entities;
using DataAccess.Repositories.Abstract;
using DataAccess.UnitOfWork;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using restaurant.Helpers;
using System.Net;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using static System.Reflection.Metadata.BlobBuilder;

namespace Business.Services.Concered
{

   

    


    public class AboutService : IAboutService
    {

        private readonly IAboutRepository _aboutRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;


        public AboutService(IAboutRepository aboutRepository,IUnitOfWork unitOfWork , IMapper mapper, IWebHostEnvironment env)
        {
            _aboutRepository = aboutRepository;
            _unitOfWork = unitOfWork;
                _mapper = mapper;
                _env = env;
            
        }





        public async Task<Response> CreateAsync(AboutCreateDto model)
        {
            var result = await new AboutCreatDtoValidator().ValidateAsync(model);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }


            var about = _mapper.Map<About>(model);

         

            if (about.ImageFile == null)
            {

                throw new ValidationException("Image daxil edilmelidir");
            }



            if (!about.ImageFile.CheckFileSize(1000))
            {
              
                throw new ValidationException("Image olcusu 1 mb cox olmamalidir");
            }


            if (!about.ImageFile.CheckFileType("image/jpeg"))
            {

                throw new ValidationException("Image jpg tipi olmalidir");
            }
            about.Image = about.ImageFile.CreateImage(_env, "img", "about");
         



            await _aboutRepository.CreateAsync(about);
            await _unitOfWork.CommitAsync();


            return new Response
            {
                Message = "about ugurla yaradildi"
            };
        }

        public async Task<Response> DeleteAsync(int id)
        {
            var about = await _aboutRepository.GetAsync(id);

            if (about is null)
            {
                throw new NotFoundException("about tapilmadi");
            }
            _aboutRepository.Delete(about);
            await _unitOfWork.CommitAsync();

            return new Response
            {
                Message = "about ugurla silindi"
            };
        }

        public async Task<Response<List<AboutResponseDto>>> GetAllAsync(string? search)
        {
            var abouts = await _aboutRepository.GetFiltered(b => search != null ?
             b.Title.Contains(search) : true).ToListAsync();


            if (abouts is null)
            {
                throw new NotFoundException("about tapilmadi");
            }
  
            return new Response<List<AboutResponseDto>>
            {
                Data = _mapper.Map<List<AboutResponseDto>>(abouts),
                Message = "ugurlu alindi"
            };



        }

        public async Task<Response<AboutResponseDto>> GetAsync(int id)
        {
            var about = await _aboutRepository.GetAsync(id);

            if (about is null)
            {
              
                throw new NotFoundException("about tapilmadi");
            }


           
            return new Response<AboutResponseDto>
            {
                Data = _mapper.Map<AboutResponseDto>(about),
                Message = "ugurlu alindi"
            };
        }

        public async Task<Response> UpdateAsync(int id,AboutUpdateDto model)
        {
            var result = await new AboutUpdateDtoValidator().ValidateAsync(model);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);

            }


            var existAbout = await _aboutRepository.GetAsync(id);
            if (existAbout is null)
            {
                throw new NotFoundException("about tapilmadi");
            }

            _mapper.Map(model, existAbout);

            if (existAbout.ImageFile == null)
            {
                throw new ValidationException("Image daxil edilmelidir");
            }



            if (!existAbout.ImageFile.CheckFileSize(1000))
            {
                throw new ValidationException("Image olcusu 1 mb cox olmamalidir");
            }


            if (!existAbout.ImageFile.CheckFileType("image/jpeg"))
            {
             

                throw new ValidationException("Image jpg tipi olmalidir");

            }



            Helper.DeleteFile(_env, existAbout.Image, "img", "about");
            existAbout.Image = existAbout.ImageFile.CreateImage(_env, "img", "about");
          
            existAbout.ModifiedDate = DateTime.Now;
           
            existAbout.Title = existAbout.Title;
            existAbout.Description = existAbout.Description;
            existAbout.Year = existAbout.Year;  
            try
            {

                 _aboutRepository.Update(existAbout);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                int a = 32;
            }


        
            return new Response
            {
                Message = "about uğurla redaktə olundu"
            };
        }
    }
}
