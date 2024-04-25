using AutoMapper;
using Business.DTOs.Menu.Request;
using Business.DTOs.Menu.Response;
using Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.MappingProfiles
{
    public class MenuMappingProfile :Profile
    {
        public MenuMappingProfile()
        {
            CreateMap<MenuCreateDto ,Menu>().ReverseMap();
            CreateMap<MenuUpdateDto ,Menu>().ReverseMap();
            CreateMap<Menu, MenuResponseDto>().ReverseMap();
        }
    }
}
