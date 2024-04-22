using Business.DTOs.Blog.Request;
using Business.DTOs.Blog.Response;
using Business.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstraction
{
    public interface IBlogService
    {
        Task<Response> CreateAsync(BlogCreateDto model);
        Task<Response> UpdateAsync(int id , BlogUpdateDto model);
        Task<Response> DeleteAsync(int id);
        Task<Response<BlogResponseDto>> GetAsync(int id);
        Task<Response<List<BlogResponseDto>>> GetAllAsync(string? search);
    }
}
