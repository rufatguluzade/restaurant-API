using AutoMapper;
using Business.DTOs.Common;
using Business.DTOs.SubMenu.Request;
using Business.DTOs.SubMenu.Response;
using Business.Exceptions;
using Business.Services.Abstraction;
using Business.Validators.SubMenu;
using Common.Entities;
using DataAccess.Repositories.Abstract;
using DataAccess.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Business.Services.Concered
{
    public class SubMenuService : ISubMenuService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISubMenuRepository _subMenuRepository;
        private readonly IMenuRepository _menuRepository;


        public SubMenuService(IMapper mapper, IUnitOfWork unitOfWork, ISubMenuRepository subMenuRepository, IMenuRepository menuRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _subMenuRepository = subMenuRepository;
            _menuRepository = menuRepository;

        }

        public async Task<Response> CreateAsync(SubMenuCreateDto model)
        {
            var result = await new SubMenuCreateDtoValidator().ValidateAsync(model);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
            if (await _subMenuRepository.IsExistAsync(m => m.Name == model.Name))
            {
                throw new ValidationException("bu adda menu movcuddur");
            }

            var subMenu = _mapper.Map<SubMenu>(model);

            if (!await _menuRepository.IsExistAsync(x=> x.Id == model.MenuId))
            {
                throw new ValidationException("gelen submenu yalnisdir");
            }
        

            await _subMenuRepository.CreateAsync(subMenu);
            await _unitOfWork.CommitAsync();

            return new Response { Message = "ugurla create olundu" };
        }

        public async Task<Response> DeleteAsync(int id)
        {
            var subMenu = await _subMenuRepository.GetAsync(id);
            if (subMenu is null) { throw new NotFoundException("SubMenu tapilmadi"); }

            _subMenuRepository.Delete(subMenu);
            await _unitOfWork.CommitAsync();

            return new Response
            {
                Message = "sub menu ugurla silindi"
            };
        }

        public async Task<Response<List<SubMenuGetMenuResponseDto>>> GetAllAsync(string? search)
        {
            try
            {
                var subMenuss = await _subMenuRepository.GetFiltered(
b => search != null ? b.Name.Contains(search) : true,
isTracking: false
, includes: new[] { "Menu" }
).ToListAsync();

                if (subMenuss is null)
                {

                    throw new NotFoundException("Hec bir subMenus tapilmadi");
                }

                return new Response<List<SubMenuGetMenuResponseDto>>
                {
                    Data = _mapper.Map<List<SubMenuGetMenuResponseDto>>(subMenuss),
                    Message = "data ugurla getirildi"
                };
            }
            catch (Exception e)
            {

                int a = 1 + 2;
            }
            var subMenus = await _subMenuRepository.GetFiltered(
        b => search != null ? b.Name.Contains(search) : true,
        isTracking: false
   ,includes: new[] { "Menu" }
    ).ToListAsync();

            if (subMenus is null)
            {

                throw new NotFoundException("Hec bir subMenus tapilmadi");
            }

            return new Response<List<SubMenuGetMenuResponseDto>>
            {
                Data = _mapper.Map<List<SubMenuGetMenuResponseDto>>(subMenus),
                Message = "data ugurla getirildi"
            };

        }


            public async Task<Response<SubMenuResponseDto>> GetAsync(int id)
        {
            var subMenu = await _subMenuRepository.GetAsync(id);

            if (subMenu is null)
            {
                throw new NotFoundException("Hec bir subMenu tapilmadi");
            }

            return new Response<SubMenuResponseDto>
            {
                Data = _mapper.Map<SubMenuResponseDto>(subMenu),
                Message = "data ugurla getirildi"
            };
        }

        public async Task<Response> UpdateAsync(int id, SubMenuUpdateDto model)
        {
            var result = await new SubMenuUpdateDtoValidator().ValidateAsync(model);



            var existSubMenu = await _subMenuRepository.GetAsync(id);
            if (existSubMenu is null)
            {
                throw new NotFoundException("submenu tapilmadi");
            }
            if (await _subMenuRepository.IsExistAsync(m => m.Name == existSubMenu.Name))
            {
                throw new ValidationException("bu adda submenu movcuddur");
            }

            _mapper.Map(model, existSubMenu);

            if (!await _menuRepository.IsExistAsync(x => x.Id == model.MenuId))
            {
                throw new ValidationException("gelen menu yalnisdir");
            }

            existSubMenu.Name = existSubMenu.Name;

            existSubMenu.MenuId = existSubMenu.MenuId;

            _subMenuRepository.Update(existSubMenu);
            await _unitOfWork.CommitAsync();

            return new Response
            {
                Message = "data update olundu"
            };


        }
    }
}
