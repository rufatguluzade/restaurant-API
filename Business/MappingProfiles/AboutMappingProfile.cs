using AutoMapper;
using Business.DTOs.About.Request;
using Business.DTOs.About.Response;
using Common.Entities;

namespace Business.MappingProfiles
{
    public class AboutMappingProfile : Profile
    {
        public AboutMappingProfile()
        {
           CreateMap<AboutCreateDto, About >().ReverseMap();
           CreateMap<AboutUpdateDto , About>().ReverseMap();


           CreateMap<About , AboutResponseDto>().ReverseMap();
                
        }
    }
}
