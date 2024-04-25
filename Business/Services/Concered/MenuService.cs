using Business.DTOs.Common;
using Business.DTOs.Menu.Request;
using Business.DTOs.Menu.Response;
using Business.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Concered
{
    public class MenuService : IMenuService
    {


        public Task<Response> CreateAsync(MenuCreateDto model)
        {
            throw new NotImplementedException();
        }

        public Task<Response> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<List<MenuResponseDto>>> GetAllAsync(string? search)
        {
            throw new NotImplementedException();
        }

        public Task<Response<MenuResponseDto>> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response> UpdateAsync(int id, MenuUpdateDto model)
        {
            throw new NotImplementedException();
        }
    }
}
