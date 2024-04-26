using AutoMapper;
using Business.DTOs.Blog.Response;
using Business.DTOs.Common;
using Business.DTOs.Product.Request;
using Business.DTOs.Product.Response;
using Business.Exceptions;
using Business.Services.Abstraction;
using Business.Validators.Product;
using Common.Entities;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.Concrete;
using DataAccess.UnitOfWork;
using DocumentFormat.OpenXml.InkML;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Concered
{
    public class ProductService : IProductService
    {

        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ISubMenuRepository _subMenuRepository;
      



        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork, IMapper mapper, ISubMenuRepository subMenuRepository)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _subMenuRepository = subMenuRepository;


        }
        public async Task<Response> CreateAsync(ProductCreateDto model)
        {
            var result = await new ProductCreateDtoValidator().ValidateAsync(model);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
            var product = _mapper.Map<Product>(model);

            if (!await _subMenuRepository.IsExistAsync(x => x.Id == model.SubMenuId))
            {
                throw new ValidationException("gelen Submenu yalnisdir");
            }


            await _productRepository.CreateAsync(product);
            await _unitOfWork.CommitAsync();

  
            return new Response
            {

                Message = "product ugurla yaradildi"
            };
        }

        public async Task<Response> DeleteAsync(int id)
        {
            var product = await _productRepository.GetAsync(id);
            if (product is null)
            {
              

                throw new NotFoundException("Mehsul tapilmadi");
            }

            _productRepository.Delete(product);
            await _unitOfWork.CommitAsync();

            return new Response
            {
                Message = "product uğurla silindi"
            };
        }

        public async Task<Response<List<ProductResponseDto>>> GetAllAsync(string? search)
        {
            var products = await _productRepository.GetFiltered(
             b => search != null ? b.Name.Contains(search) : true,
             isTracking: false,
             includes: new[] { "SubMenu" }
         ).ToListAsync();





            if (products is null)
            {
                throw new NotFoundException("product tapilmadi");
            }


            return new Response<List<ProductResponseDto>>
            {
                Data = _mapper.Map<List<ProductResponseDto>>(products),
                Message = "ugurlu alindi"
            };
        }

        public async Task<Response<ProductResponseDto>> GetAsync(int id)
        {
            var product = await _productRepository.GetSingleAsync(b => b.Id == id, "SubMenu");

            if (product is null)
            {
               
                throw new NotFoundException("product tapilmadi");
            }


         
            return new Response<ProductResponseDto>
            {
                Data = _mapper.Map<ProductResponseDto>(product),
                Message = $"id-si {id} olan product tapildi"
            };
        }

        public async Task<Response> UpdateAsync(int id, ProductUpdateDto model)
        {
            var result = await new ProductUpdateDtoValidator().ValidateAsync(model);
            if (!result.IsValid)
            {

                throw new ValidationException(result.Errors);
            }

            var existProduct = await _productRepository.GetAsync(id);
            if (existProduct is null)
            {
               
                throw new NotFoundException("Product tapılmadı");
            }



            _mapper.Map(model, existProduct);

            if (!await _subMenuRepository.IsExistAsync(x => x.Id == model.SubMenuId))
            {
                throw new ValidationException("gelen Sub Menu yalnisdir");
            }


           
            existProduct.Name = existProduct.Name;
            existProduct.ModifiedDate = DateTime.Now;
            existProduct.SubMenuId = existProduct.SubMenuId;
            existProduct.Composition = existProduct.Composition;
            existProduct.Price = existProduct.Price;

            _productRepository.Update(existProduct);
            await _unitOfWork.CommitAsync();


            return new Response
            {
                Message = "product uğurla redaktə olundu"
            };
        }
    }
}
