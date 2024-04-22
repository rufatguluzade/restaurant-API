using AutoMapper;
using Business.DTOs.Tag.Request;
using Business.DTOs.Tag.Response;
using Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.MappingProfiles
{
    public class TagMappingProfile :Profile
    {
        public TagMappingProfile()
        {
            CreateMap<TagCreateDto , Tag>().ReverseMap();
            CreateMap<TagUpdateDto , Tag>().ReverseMap();
            CreateMap<Tag , TagResponseDto>().ReverseMap();
        }
    }
}
