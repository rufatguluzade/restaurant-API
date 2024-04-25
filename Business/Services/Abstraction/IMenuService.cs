using Business.DTOs.Blog.Request;
using Business.DTOs.Blog.Response;
using Business.DTOs.Common;
using Business.DTOs.Menu.Request;
using Business.DTOs.Menu.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstraction
{
    public interface IMenuService 
    {
        Task<Response> CreateAsync(MenuCreateDto model);
        Task<Response> UpdateAsync(int id, MenuUpdateDto model);
        Task<Response> DeleteAsync(int id);
        Task<Response<MenuResponseDto>> GetAsync(int id);
        Task<Response<List<MenuResponseDto>>> GetAllAsync(string? search);
    }
}
