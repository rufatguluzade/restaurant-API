using Business.DTOs.Common;
using Business.DTOs.Product.Request;
using Business.DTOs.Product.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstraction
{
    public interface IProductService
    {
        Task<Response> CreateAsync(ProductCreateDto model);
        Task<Response> UpdateAsync(int id, ProductUpdateDto model);
        Task<Response<ProductResponseDto>> GetAsync(int id);
        Task<Response<List<ProductResponseDto>>> GetAllAsync(string? search);
        Task<Response> DeleteAsync(int id);
    }
}
