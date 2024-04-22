using AutoMapper;
using Business.DTOs.About.Request;
using Business.DTOs.About.Response;
using Business.DTOs.RestaurantLocations.Location.Request;
using Business.DTOs.RestaurantLocations.Location.Response;
using Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.MappingProfiles
{
    public class LocationsMappingProfile :Profile
    {
        public LocationsMappingProfile()
        {
            CreateMap<LocationCreateDto, Locations>().ReverseMap();
            CreateMap<LocationUpdateDto, Locations>().ReverseMap();


            CreateMap<Locations, LocationResponseDto>().ReverseMap();
        }
    }
}
