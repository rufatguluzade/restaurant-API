﻿using AutoMapper;
using Business.DTOs.Common;
using Business.DTOs.Tag.Request;
using Business.DTOs.Tag.Response;
using Business.Exceptions;
using Business.Services.Abstraction;
using Business.Validators.Tag;
using Common.Entities;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.Concrete;
using DataAccess.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Business.Services.Concered
{
    public class TagService : ITagService
    {

        private readonly ITagRepository _tagRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public TagService(ITagRepository tagRepository,IUnitOfWork unitOfWork , IMapper mapper)
        {
            _mapper = mapper;
            _tagRepository = tagRepository; 
            _unitOfWork = unitOfWork;
        }

        public async Task<Response> CreateAsync(TagCreateDto model)
        {
            var result = await new TagCreateDtoValidator().ValidateAsync(model);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
            if (await _tagRepository.IsExistAsync(m => m.Name == model.Name))
            {
                throw new ValidationException("bu tag menu movcuddur");
            }

            var tag = _mapper.Map<Tag>(model);

            await _tagRepository.CreateAsync(tag);
            await _unitOfWork.CommitAsync();

            return new Response
            {
                Message = "Tag ugurla yaradildi"
            };

            
        }

        public async Task<Response> DeleteAsync(int id)
        {
           var tag = await _tagRepository.GetAsync(id);

            if (tag is null)
            {
                throw new NotFoundException("Tag tapilmadi");
            }


            _tagRepository.Delete(tag);
            await _unitOfWork.CommitAsync();

            return new Response
            {
                Message = "Tag ugurla delete olundu"
            };

        }

        public async Task<Response<List<TagResponseDto>>> GetAllAsync([FromQuery]string? search)
        {
            var tags = await _tagRepository.GetFiltered(b => search != null ?
            b.Name.Contains(search) : true).ToListAsync();


            if (tags is null)
            {
                throw new NotFoundException("Tag tapilmadi");
            }

            return new Response<List<TagResponseDto>>
            {
                Data = _mapper.Map<List<TagResponseDto>>(tags),
                Message = "Taglar ugurla gosterildi"
            };
        }

        public async Task<Response<TagResponseDto>> GetAsync(int id)
        {
            var tag = await _tagRepository.GetAsync(id);

            if (tag is null)
            {
                throw new NotFoundException("Tag tapilmadi");
            }

            return new Response<TagResponseDto>
            {
                Data = _mapper.Map<TagResponseDto>(tag),
                Message = "Tag ugurla gosterildi"
            };
        }

        public async Task<Response> UpdateAsync(int id, TagUpdateDto model)
        {
            var result = await new TagUpdateDtoValidator().ValidateAsync(model);

            if (!result.IsValid)
            {
                throw new Exceptions.ValidationException(result.Errors);
            }

            var existTag = await _tagRepository.GetAsync(id);

            if (await _tagRepository.IsExistAsync(m => m.Name == model.Name))
            {
                throw new ValidationException("bu adda tag movcuddur");
            }

            if (existTag is null)
            {
                throw new NotFoundException("Tag tapilmadi");
            }

            _mapper.Map(model, existTag);

            existTag.ModifiedDate = DateTime.Now;
            existTag.Name = model.Name;

            _tagRepository.Update(existTag);
            await _unitOfWork.CommitAsync();

            return new Response
            {
                Message = "Tag ugurla update oldu"
            };

        }
    }
}
