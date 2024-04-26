using Business.DTOs.Common;
using Business.DTOs.SubMenu.Request;
using Business.DTOs.SubMenu.Response;
using Business.Services.Abstraction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubSubMenuController : ControllerBase
    {

        private readonly ISubMenuService _subMenuService;

        public SubSubMenuController(ISubMenuService subMenuService)
        {
            _subMenuService = subMenuService;
        }

        #region Documentation
        /// <summary>
        /// SubMenu yaradılması üçün
        /// </summary>
        /// <param name="model"></param>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Response))]
        #endregion
        [HttpPost("Create")]
        // [Authorize(Roles = "Admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        public async Task<Response> CreateAsync([FromBody] SubMenuCreateDto model)
        {
            return await _subMenuService.CreateAsync(model);
        }


        #region Documentation
        /// <summary>
        /// SubMenu redakte etmek üçün
        /// </summary>
        /// <param name="model"></param>
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Response))]
        #endregion
        [HttpPut("Update")]
        public async Task<Response> UpdateAsync(int id, [FromBody] SubMenuUpdateDto model)
        {
            return await _subMenuService.UpdateAsync(id, model);
        }



        #region Documentation
        /// <summary>
        ///  SubMenu silinməsi
        /// </summary>
        /// <param name="id"></param>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Response))]
        #endregion
        [HttpDelete("Delete")]
        public async Task<Response> DeleteAsync(int id)
        {
            return await _subMenuService.DeleteAsync(id);
        }



        #region Documentation
        /// <summary>
        ///  SubMenu id parametrinə görə götürülməsi üçün
        /// </summary>
        /// <param name="id"></param>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<SubMenuResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Response))]
        #endregion
        [HttpGet("GetById")]
        public async Task<Response<SubMenuResponseDto>> GetAsync(int id)
        {
            return await (_subMenuService.GetAsync(id));
        }



        #region Documentation
        /// <summary>
        /// SubMenu siyahısını götürmək üçün
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<List<SubMenuResponseDto>>))]
        #endregion
        [HttpGet("GetAll")]
        public async Task<Response<List<SubMenuResponseDto>>> GetAllAsync([FromQuery] string? search)
        {
            return await _subMenuService.GetAllAsync(search);
        }
    }
}
