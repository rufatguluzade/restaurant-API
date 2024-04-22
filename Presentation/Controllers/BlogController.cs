using Business.DTOs.About.Request;
using Business.DTOs.About.Response;
using Business.DTOs.Blog.Request;
using Business.DTOs.Blog.Response;
using Business.DTOs.Common;
using Business.Services.Abstraction;
using Business.Services.Concered;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;

        }




        #region Documentation
        /// <summary>
        /// blog yaradılması üçün
        /// </summary>
        /// <param name="model"></param>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Response))]
        #endregion
        [HttpPost("Create")]
        public async Task<Response> CreateAsync([FromForm]BlogCreateDto model)
        {
            return await _blogService.CreateAsync(model);  
        }


        #region Documentation
        /// <summary>
        /// Blog redakte etmek üçün
        /// </summary>
        /// <param name="model"></param>
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Response))]
        #endregion
        [HttpPut("Update")]
        public async Task<Response> UpdateAsync(int id, [FromForm] BlogUpdateDto model)
        {
            return await _blogService.UpdateAsync(id, model);
        }



        #region Documentation
        /// <summary>
        ///  blog silinməsi
        /// </summary>
        /// <param name="id"></param>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Response))]
        #endregion
        [HttpDelete("Delete")]
        public async Task<Response> DeleteAsync(int id)
        {
            return await _blogService.DeleteAsync(id);
        }



        #region Documentation
        /// <summary>
        ///  blog id parametrinə görə götürülməsi üçün
        /// </summary>
        /// <param name="id"></param>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<BlogResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Response))]
        #endregion
        [HttpGet("GetById")]
        public async Task<Response<BlogResponseDto>> GetAsync(int id)
        {
            return await _blogService.GetAsync(id);
        }



        #region Documentation
        /// <summary>
        /// blog siyahısını götürmək üçün
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<List<BlogResponseDto>>))]
        #endregion
        [HttpGet("GetAll")]
        public async Task<Response<List<BlogResponseDto>>> GetAllAsync([FromQuery]string? search)
        {
            return await _blogService.GetAllAsync(search);
        }
    }
}
