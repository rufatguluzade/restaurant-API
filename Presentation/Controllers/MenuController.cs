using Business.DTOs.Common;
using Business.DTOs.Menu.Request;
using Business.DTOs.Menu.Response;
using Business.Services.Abstraction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {

        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        #region Documentation
        /// <summary>
        /// Menu yaradılması üçün
        /// </summary>
        /// <param name="model"></param>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Response))]
        #endregion
        [HttpPost("Create")]
        // [Authorize(Roles = "Admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        public async Task<Response> CreateAsync([FromBody] MenuCreateDto model)
        {
            return await _menuService.CreateAsync(model);
        }


        #region Documentation
        /// <summary>
        /// Menu redakte etmek üçün
        /// </summary>
        /// <param name="model"></param>
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Response))]
        #endregion
        [HttpPut("Update")]
        public async Task<Response> UpdateAsync(int id, [FromBody] MenuUpdateDto model)
        {
            return await _menuService.UpdateAsync(id, model);
        }



        #region Documentation
        /// <summary>
        ///  Menu silinməsi
        /// </summary>
        /// <param name="id"></param>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Response))]
        #endregion
        [HttpDelete("Delete")]
        public async Task<Response> DeleteAsync(int id)
        {
            return await _menuService.DeleteAsync(id);
        }



        #region Documentation
        /// <summary>
        ///  Menu id parametrinə görə götürülməsi üçün
        /// </summary>
        /// <param name="id"></param>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<MenuResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Response))]
        #endregion
        [HttpGet("GetById")]
        public async Task<Response<MenuResponseDto>> GetAsync(int id)
        {
            return await (_menuService.GetAsync(id));
        }



        #region Documentation
        /// <summary>
        /// Menu siyahısını götürmək üçün
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<List<MenuResponseDto>>))]
        #endregion
        [HttpGet()]
        public async Task<Response<List<MenuResponseDto>>> GetAllAsync([FromQuery] string? search)
        {
            return await _menuService.GetAllAsync(search);
        }
    }
}
