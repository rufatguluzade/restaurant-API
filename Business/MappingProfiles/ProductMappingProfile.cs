﻿using AutoMapper;
using Business.DTOs.Product.Request;
using Business.DTOs.Product.Response;
using Common.Entities;


namespace Business.MappingProfiles
{
    public class ProductMappingProfile :Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<ProductCreateDto, Product>().ReverseMap();
            CreateMap<ProductUpdateDto, Product>().ReverseMap();


            CreateMap<Product, ProductResponseDto>().ReverseMap();
        }
    }
}
