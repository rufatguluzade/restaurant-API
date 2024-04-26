using AutoMapper;
using Business.DTOs.SubMenu.Request;
using Business.DTOs.SubMenu.Response;
using Common.Entities;
using DataAccess.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.MappingProfiles
{
    public class SubMenuMappingProfile :Profile
    {
        public SubMenuMappingProfile()
        {
            CreateMap<SubMenuCreateDto, SubMenu>().ReverseMap();
            CreateMap<SubMenuUpdateDto, SubMenu>().ReverseMap();
            CreateMap<SubMenu , SubMenuResponseDto>().ReverseMap(); 

        }
    }
}
