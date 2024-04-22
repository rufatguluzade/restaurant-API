using Business.DTOs.About.Request;
using Business.DTOs.About.Response;
using Business.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstraction
{
    public interface IAboutService
    {
        Task<Response> CreateAsync(AboutCreateDto model);
        Task<Response> UpdateAsync(int id,AboutUpdateDto model);
        Task<Response> DeleteAsync(int id);
        Task<Response<AboutResponseDto>> GetAsync(int id);
        Task<Response<List<AboutResponseDto>>> GetAllAsync(string? search);

    }
}
