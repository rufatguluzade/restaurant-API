using Business.DTOs.Common;
using Business.DTOs.RestaurantLocations.OpeningHours.Request;
using Business.DTOs.RestaurantLocations.OpeningHours.Response;
using Business.DTOs.SubMenu.Request;
using Business.DTOs.SubMenu.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstraction
{
    public interface ISubMenuService 
    {
        Task<Response> CreateAsync(SubMenuCreateDto model);
        Task<Response> UpdateAsync(int id, SubMenuUpdateDto model);
        Task<Response> DeleteAsync(int id);
        Task<Response<SubMenuResponseDto>> GetAsync(int id);
        Task<Response<List<SubMenuGetMenuResponseDto>>> GetAllAsync(string? search);
    }
}
