using AutoMapper;
using Business.DTOs.About.Response;
using Business.DTOs.Blog.Request;
using Business.DTOs.Blog.Response;
using Business.DTOs.Common;
using Business.Exceptions;
using Business.Extensions;
using Business.Services.Abstraction;
using Business.Validators.Blog;
using Common.Entities;
using DataAccess.AboutRepository.Concrete;
using DataAccess.Context;
using DataAccess.Repositories.Abstract;
using DataAccess.UnitOfWork;
using DocumentFormat.OpenXml.Vml.Spreadsheet;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using restaurant.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Concered
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _env;
        private readonly ITagRepository _tagRepository;
        private readonly AppDbContext _context;


        public BlogService(IBlogRepository blogRepository , IMapper mapper , IUnitOfWork unitOfWork, IWebHostEnvironment env,ITagRepository tagRepository,AppDbContext context)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _env = env;
            _tagRepository = tagRepository;
            _context = context;
        }
        public async Task<Response> CreateAsync(BlogCreateDto model)
        {
            var result = await new BlogCreateDtoValidator().ValidateAsync(model);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }


            var blog = _mapper.Map<Blog>(model);    

            List<BlogTag> blogTags = new List<BlogTag>();

            foreach (int tagId in blog.TagIds)
            {
                if (blog.TagIds.Where(t => t == tagId).Count() > 1)
                {
                    throw new ValidationException("Bir tagdan bir defe secilmelidir");
                }

                if (!await _tagRepository.IsExistAsync(t => t.Id == tagId))
                {
                    throw new ValidationException("secilen tag yalnisdir");
                }

                BlogTag blogTag = new BlogTag
                {
                    CreatedDate = DateTime.UtcNow,


                    TagId = tagId

                };

                //taglari bos liste add etdik
                blogTags.Add(blogTag);
            }


            if (blog.ImageFile == null)
            {

                throw new ValidationException("Image daxil edilmelidir");
            }



            if (!blog.ImageFile.CheckFileSize(1000))
            {
              
                throw new ValidationException("Image olcusu 1 mb cox olmamalidir");
            }


            if (!blog.ImageFile.CheckFileType("image/jpeg"))
            {
             

                throw new ValidationException("Image jpg tipi olmalidir");

            }


            blog.Image = blog.ImageFile.CreateImage(_env, "img", "blog");
            blog.BlogTags = blogTags;



            await _blogRepository.CreateAsync(blog);
            await _unitOfWork.CommitAsync();






           
            return new Response
            {

                Message = "blog ugurla yaradildi"
            };


        }

        public async Task<Response> DeleteAsync(int id)
        {
           var blog = await _blogRepository.GetAsync(id);

            if (blog is null) {
                throw new NotFoundException("blog tapilmadi");
            }


            _blogRepository.Delete(blog);
            await _unitOfWork.CommitAsync();

            return new Response
            {
                Message = "blog ugurla silindi"
            };

        }

        public async Task<Response<List<BlogResponseDto>>> GetAllAsync(string? search)
        {
            var blogs = await _blogRepository.GetFiltered(
            b => search != null ? b.Title1.Contains(search) : true,
            isTracking: false,
            includes: new[] { "BlogTags.Tag"}
        ).ToListAsync();





            if (blogs is null)
            {
                throw new NotFoundException("blog tapilmadi");
            }


            return new Response<List<BlogResponseDto>>
            {
                Data = _mapper.Map<List<BlogResponseDto>>(blogs),
                Message = "ugurlu alindi"
            };
        }

        public async Task<Response<BlogResponseDto>> GetAsync(int id)
        {
            var blog = await _blogRepository.GetSingleAsync(b => b.Id == id, "BlogTags.Tag");

            if (blog is null)
            {
                throw new NotFoundException("Blog tapilmadi");
            }



            return new Response<BlogResponseDto>
            {
                Data = _mapper.Map<BlogResponseDto>(blog),
                Message = "blog ugurla getirildi"
            };

                     
        }

        public async Task<Response> UpdateAsync(int id, BlogUpdateDto model)
        {
            var result = await new BlogUpdateDtoValidator().ValidateAsync(model);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }


            var existBlog = await _blogRepository.GetAsync(id);

            if (existBlog is null)
            {
                throw new NotFoundException("blog tapilmadi");
            }

            _mapper.Map(existBlog, model);


            List<BlogTag> blogTags = new List<BlogTag>();

            foreach (int tagId in existBlog.TagIds)
            {
                if (existBlog.TagIds.Where(t => t == tagId).Count() > 1)
                {
     
                    throw new ValidationException("Bir tagdan bir defe secilmelidir");

                }

                if (!await _blogRepository.IsExistAsync(t => t.Id == tagId))
                {
        
                    throw new ValidationException("secilen tag yalnisdir");

                }

                BlogTag blogTag = new BlogTag
                {
                    CreatedDate = DateTime.UtcNow,


                    TagId = tagId

                };

                //taglari bos liste add etdik
                blogTags.Add(blogTag);
            }


            if (existBlog.ImageFile == null)
            {
               
                throw new ValidationException("Image daxil edilmelidir");
            }



            if (!existBlog.ImageFile.CheckFileSize(1000))
            {
        
                throw new ValidationException("Image olcusu 1 mb cox olmamalidir");
            }


            if (!existBlog.ImageFile.CheckFileType("image/jpeg"))
            {


                throw new ValidationException("Image jpg tipi olmalidir");

            }



            Helper.DeleteFile(_env, existBlog.Image, "img", "blog");
            existBlog.Image = existBlog.ImageFile.CreateImage(_env, "img", "blog");
            existBlog.BlogTags = blogTags;
            existBlog.ModifiedDate = DateTime.Now;
            existBlog.Title1 = existBlog.Title1;
            existBlog.Title2 = existBlog.Title2;
            existBlog.Description1 = existBlog.Description1;
            existBlog.Description2 = existBlog.Description2;
            existBlog.Author = existBlog.Author;
     


            try
            {

                _blogRepository.Update(existBlog);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                int a = 32;
            }


     
            return new Response
            {
                Message = "blog uğurla redaktə olundu"
            };


        }
    }
}
