
using Business.DTOs.Common;
using Business.DTOs.RestaurantLocations.OpeningHours.Request;
using Business.DTOs.RestaurantLocations.OpeningHours.Response;
using Business.DTOs.Tag.Request;
using Business.DTOs.Tag.Response;


namespace Business.Services.Abstraction
{
    public interface IOpeningHoursService 
    {
        Task<Response> CreateAsync(OpeningHoursCreateDto model);
        Task<Response> UpdateAsync(int id, OpeningHoursUpdateDto model);
        Task<Response> DeleteAsync(int id);
        Task<Response<OpeningHoursResponseDto>> GetAsync(int id);
        Task<Response<List<OpeningHoursResponseDto>>> GetAllAsync(string? search);
    }
}
