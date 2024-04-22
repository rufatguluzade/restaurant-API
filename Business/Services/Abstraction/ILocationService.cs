using Business.DTOs.Common;
using Business.DTOs.RestaurantLocations.Location.Request;
using Business.DTOs.RestaurantLocations.Location.Response;
using Business.DTOs.RestaurantLocations.OpeningHours.Request;
using Business.DTOs.RestaurantLocations.OpeningHours.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstraction
{
    public interface ILocationService
    {

        Task<Response> CreateAsync(LocationCreateDto model);
        Task<Response> UpdateAsync(int id, LocationUpdateDto model);
        Task<Response> DeleteAsync(int id);
        Task<Response<LocationResponseDto>> GetAsync(int id);
        Task<Response<List<LocationResponseDto>>> GetAllAsync(string? search);
    }
}
