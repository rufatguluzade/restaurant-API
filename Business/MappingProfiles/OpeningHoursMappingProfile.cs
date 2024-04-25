using AutoMapper;
using Business.DTOs.RestaurantLocations.OpeningHours.Request;
using Business.DTOs.RestaurantLocations.OpeningHours.Response;
using Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.MappingProfiles
{
    public class OpeningHoursMappingProfile :Profile
    {
        public OpeningHoursMappingProfile()
        {
            CreateMap<OpeningHoursCreateDto , OpeningHours>().ReverseMap();
            CreateMap<OpeningHoursUpdateDto, OpeningHours>().ReverseMap();

            CreateMap<OpeningHours , OpeningHoursResponseDto>().ReverseMap();


        }
    }
}
