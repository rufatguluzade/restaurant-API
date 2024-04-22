
using Business.DTOs.Common;
using Business.DTOs.Tag.Request;
using Business.DTOs.Tag.Response;
using Business.Services.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly ITagService _tagService;


        public TagsController(ITagService tagService)
        {
            _tagService = tagService;
        }


        #region Documentation
        /// <summary>
        /// Tag yaradılması üçün
        /// </summary>
        /// <param name="model"></param>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Response))]
        #endregion
        [HttpPost("Create")]
        // [Authorize(Roles = "Admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        public async Task<Response> CreateAsync([FromBody] TagCreateDto model)
        {
            return await _tagService.CreateAsync(model);
        }


        #region Documentation
        /// <summary>
        /// Tag redakte etmek üçün
        /// </summary>
        /// <param name="model"></param>
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Response))]
        #endregion
        [HttpPut("Update")]
        public async Task<Response> UpdateAsync(int id, [FromBody] TagUpdateDto model)
        {
            return await _tagService.UpdateAsync(id, model);
        }



        #region Documentation
        /// <summary>
        ///  tag silinməsi
        /// </summary>
        /// <param name="id"></param>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Response))]
        #endregion
        [HttpDelete("Delete")]
        public async Task<Response> DeleteAsync(int id)
        {
            return await _tagService.DeleteAsync(id);
        }



        #region Documentation
        /// <summary>
        ///  tag id parametrinə görə götürülməsi üçün
        /// </summary>
        /// <param name="id"></param>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<TagResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Response))]
        #endregion
        [HttpGet("GetById")]
        public async Task<Response<TagResponseDto>> GetAsync(int id)
        {
            return await _tagService.GetAsync(id);
        }



        #region Documentation
        /// <summary>
        /// tag siyahısını götürmək üçün
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<List<TagResponseDto>>))]
        #endregion
        [HttpGet()]
        public async Task<Response<List<TagResponseDto>>> GetAllAsync(string? search)
        {
            return await _tagService.GetAllAsync(search);
                
                
        }

    }
}
