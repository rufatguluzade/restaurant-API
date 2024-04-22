using AutoMapper;
using Business.DTOs.Common;
using Business.DTOs.RestaurantLocations.Location.Request;
using Business.DTOs.RestaurantLocations.Location.Response;
using Business.DTOs.RestaurantLocations.OpeningHours.Response;
using Business.Exceptions;
using Business.Services.Abstraction;
using Business.Validators.Restaurant.Location;
using Business.Validators.Restaurant.OpeningHours;
using Common.Entities;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.Concrete;
using DataAccess.UnitOfWork;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.EntityFrameworkCore;

namespace Business.Services.Concered
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;



        public LocationService(ILocationRepository locationRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _locationRepository = locationRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;


        }

        public async Task<Response> CreateAsync(LocationCreateDto model)
        {
            var result = await new LocationCreateDtoValidator().ValidateAsync(model);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            var location = _mapper.Map<Locations>(model);

            if (!await _locationRepository.IsExistAsync(c => c.Id == location.OpeningHoursId))
            {
                throw new ValidationException("gelen opening hours yalnisdir");
            }

            await _locationRepository.CreateAsync(location);
            await _unitOfWork.CommitAsync();





           
            return new Response
            {

                Message = "Location ugurla yaradildi"
            };

        }

        public async Task<Response> DeleteAsync(int id)
        {
            var location = await _locationRepository.GetAsync(id);


            if (location == null) throw new ValidationException($" Id-si {id} olan location movcud deyil");

            _locationRepository.Delete(location);
            await _unitOfWork.CommitAsync();

            return new Response
            {
                Message = "location ugurla silindi"
            };
        }

        public async Task<Response<List<LocationResponseDto>>> GetAllAsync(string? search)
        {
            var locations = await _locationRepository.GetFiltered(
         b => search != null ? b.Name.Contains(search) : true,
         isTracking: false,
         includes: new[] { "Locations.OpeningHours" }
     ).ToListAsync();

            if (locations is null)
            {

                throw new NotFoundException("Hec bir location tapilmadi");
            }

            return new Response<List<LocationResponseDto>>
            {
                Data = _mapper.Map<List<LocationResponseDto>>(locations),
                Message = "data ugurla getirildi"
            };

          
        }

        public async Task<Response<LocationResponseDto>> GetAsync(int id)
        {
            var location = await _locationRepository.GetAsync(id);

            if (location is null)
            {
                throw new NotFoundException("Hec bir location tapilmadi");
            }

            return new Response<LocationResponseDto>
            {
                Data = _mapper.Map<LocationResponseDto>(location),
                Message = "data ugurla getirildi"
            };
        }

        public async Task<Response> UpdateAsync(int id, LocationUpdateDto model)
        {
            var result = await new LocationUpdateDtoValidator().ValidateAsync(model);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }


            var existLocation = await _locationRepository.GetAsync(id);
            if (existLocation is null)
            {
                throw new NotFoundException("location tapilmadi");
            }

            _mapper.Map(model, existLocation);


            existLocation.Location = existLocation.Location;
            existLocation.OpeningHoursId = existLocation.OpeningHoursId;
            existLocation.Description = existLocation.Description;
            existLocation.Email = existLocation.Email;
            existLocation.Name = existLocation.Name;
            existLocation.Phone = existLocation.Phone;
            existLocation.ModifiedDate = DateTime.Now;
         



            _locationRepository.Update(existLocation);
            await _unitOfWork.CommitAsync();

            return new Response<LocationResponseDto>
            {
                Message = "ugurla update olundu"
            };
        }
    }
}
