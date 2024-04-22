using AutoMapper;
using Business.DTOs.Common;
using Business.DTOs.RestaurantLocations.OpeningHours.Request;
using Business.DTOs.RestaurantLocations.OpeningHours.Response;
using Business.Exceptions;
using Business.Services.Abstraction;
using Business.Validators.Restaurant.OpeningHours;
using Common.Entities;
using DataAccess.AboutRepository.Concrete;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.Concrete;
using DataAccess.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Business.Services.Concered
{
    public class OpeningHoursService : IOpeningHoursService
    {
        private readonly IOpeningHoursRepository _openingHoursRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;



        public OpeningHoursService(IOpeningHoursRepository openingHoursRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _openingHoursRepository = openingHoursRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
     

        }


        public async Task<Response> CreateAsync(OpeningHoursCreateDto model)
        {
            var result = await new OpeningHoursCreateDtoValidator().ValidateAsync(model);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }


            var openHours = _mapper.Map<OpeningHours>(model);

     

            await _openingHoursRepository.CreateAsync(openHours);
            await _unitOfWork.CommitAsync();

            return new Response { Message = "Open Time yaradildi" };



        }

        public async Task<Response> DeleteAsync(int id)
        {
            var openHour = await _openingHoursRepository.GetAsync(id);

            if (openHour is null)
            {
                throw new NotFoundException("open hour tapilmadi");
            }


            _openingHoursRepository.Delete(openHour);
            await _unitOfWork.CommitAsync();

            return new Response
            {
                Message = "open hour ugurla silindi"
            };
        }

        public  async Task<Response<List<OpeningHoursResponseDto>>> GetAllAsync(string? search)
        {
            var openingHours= await _openingHoursRepository.GetFiltered(
            b => search != null ? b.OpeningTime.ToString().Contains(search) : true,
            isTracking: false,
            includes: new[] { "OpeningHours.Locations" }
        ).ToListAsync();

            if (openingHours is null)
            {

                throw new NotFoundException("Hec bir time tapilmadi");
            }

            return new Response<List<OpeningHoursResponseDto>>
            {
                Data = _mapper.Map<List<OpeningHoursResponseDto>>(openingHours),
                Message = "data ugurla getirildi"
            };

        }

        public async Task<Response<OpeningHoursResponseDto>> GetAsync(int id)
        {
            var openHour = await _openingHoursRepository.GetAsync(id);

            if (openHour is null)
            {
                throw new NotFoundException("Hec bir time tapilmadi"); 
            }

            return new Response<OpeningHoursResponseDto>
            {
                Data = _mapper.Map<OpeningHoursResponseDto>(openHour),
                Message = "data ugurla getirildi"
            };
        }

        public async Task<Response> UpdateAsync(int id, OpeningHoursUpdateDto model)
        {
            var result = await new OpeningHoursUpdateDtoValidator().ValidateAsync(model);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }


            var existOpenhour = await _openingHoursRepository.GetAsync(id);
            if (existOpenhour is null)
            {
                throw new NotFoundException("time tapilmadi");
            }

            _mapper.Map(model, existOpenhour);

            existOpenhour.DayOfWeek = existOpenhour.DayOfWeek;
            existOpenhour.ModifiedDate = DateTime.Now;
            existOpenhour.OpeningTime = existOpenhour.OpeningTime;
            existOpenhour.ClosingTime = existOpenhour.ClosingTime;
           


            _openingHoursRepository.Update(existOpenhour);
            await _unitOfWork.CommitAsync();

            return new Response<OpeningHoursResponseDto>
            {
                Message = "ugurla update olundu"
            };


        }
    }
}
