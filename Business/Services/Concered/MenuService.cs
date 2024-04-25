using AutoMapper;
using Business.DTOs.Common;
using Business.DTOs.Menu.Request;
using Business.DTOs.Menu.Response;
using Business.DTOs.RestaurantLocations.Location.Response;
using Business.Exceptions;
using Business.Services.Abstraction;
using Business.Validators.Menu;
using Business.Validators.Restaurant.Location;
using Common.Entities;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.Concrete;
using DataAccess.UnitOfWork;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Concered
{
    public class MenuService : IMenuService
    {

        private readonly IMenuRepository _menuRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;



        public MenuService(IMenuRepository menuRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _menuRepository = menuRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;


        }

        public async Task<Response> CreateAsync(MenuCreateDto model)
        {
            var result =await new MenuCreateDtoValidator().ValidateAsync(model);

            if(!result.IsValid){
                throw new ValidationException(result.Errors);
            }

            if (await _menuRepository.IsExistAsync(m=> m.Name == model.Name))
            {
                throw new ValidationException("bu adda menu movcuddur");
            }
            var menu = _mapper.Map<Menu>(model);

            await _menuRepository.CreateAsync(menu);
            await _unitOfWork.CommitAsync();

            return new Response
            {

                Message = "menu ugurla yaradildi"
            };

        }

        public async Task<Response> DeleteAsync(int id)
        {
            var menu = await _menuRepository.GetAsync(id);


            if (menu == null) throw new ValidationException($" Id-si {id} olan menu movcud deyil");

            _menuRepository.Delete(menu);
            await _unitOfWork.CommitAsync();

            return new Response
            {
                Message = "menu ugurla silindi"
            };
        }

        public async Task<Response<List<MenuResponseDto>>> GetAllAsync(string? search)
        {

            var menus = await _menuRepository.GetFiltered(
         b => search != null ? b.Name.Contains(search) : true,
         isTracking: false).ToListAsync();

            if (menus is null)
            {

                throw new NotFoundException("Hec bir menu tapilmadi");
            }

            return new Response<List<MenuResponseDto>>
            {
                Data = _mapper.Map<List<MenuResponseDto>>(menus),
                Message = "data ugurla getirildi"
            };
        }

        public async Task<Response<MenuResponseDto>> GetAsync(int id)
        {
            var menu = await _menuRepository.GetAsync(id);

            if (menu is null)
            {
                throw new NotFoundException("Hec bir menu tapilmadi");
            }

            return new Response<MenuResponseDto>
            {
                Data = _mapper.Map<MenuResponseDto>(menu),
                Message = "data ugurla getirildi"
            };
        }

        public async Task<Response> UpdateAsync(int id, MenuUpdateDto model)
        {
            var result = await new MenuUpdateDtoValidator().ValidateAsync(model);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

         

            var existMenu = await _menuRepository.GetAsync(id);

            if (await _menuRepository.IsExistAsync(m => m.Name == existMenu.Name))
            {
                throw new ValidationException("bu adda menu movcuddur");
            }
            if (existMenu is null)
            {
                throw new NotFoundException("menu tapilmadi");
            }

            _mapper.Map(model, existMenu);



            existMenu.Name = existMenu.Name;
            existMenu.ModifiedDate = DateTime.Now;




            _menuRepository.Update(existMenu);
            await _unitOfWork.CommitAsync();

            return new Response<MenuResponseDto>
            {
                Message = "ugurla update olundu"
            };
        }
    }
}
