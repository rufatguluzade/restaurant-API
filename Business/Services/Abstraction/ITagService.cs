using Business.DTOs.Common;
using Business.DTOs.Tag.Request;
using Business.DTOs.Tag.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstraction
{
    public interface ITagService
    {
        Task<Response> CreateAsync(TagCreateDto model);
        Task<Response> UpdateAsync(int id,TagUpdateDto model);
        Task<Response> DeleteAsync(int id);
        Task<Response<TagResponseDto>> GetAsync(int id);
        Task<Response<List<TagResponseDto>>> GetAllAsync(string? search);

    }
}
