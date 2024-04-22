
using Business.DTOs.Common;
using Business.DTOs.RestaurantLocations.OpeningHours.Request;
using Business.DTOs.RestaurantLocations.OpeningHours.Response;
using Business.Services.Abstraction;
using Business.Services.Concered;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpeningHoursController : ControllerBase
    {
        private readonly IOpeningHoursService _openingHoursService;

        public OpeningHoursController(IOpeningHoursService openingHoursService)
        {
            _openingHoursService = openingHoursService;
        }



        #region Documentation
        /// <summary>
        /// OpeningHours yaradılması üçün
        /// </summary>
        /// <param name="model"></param>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Response))]
        #endregion
        [HttpPost("Create")]
        // [Authorize(Roles = "Admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        public async Task<Response> CreateAsync([FromForm] OpeningHoursCreateDto model)
        {
            return await _openingHoursService.CreateAsync(model);
        }


        #region Documentation
        /// <summary>
        /// OpeningHours redakte etmek üçün
        /// </summary>
        /// <param name="model"></param>
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Response))]
        #endregion
        [HttpPut("Update")]
        public async Task<Response> UpdateAsync(int id, [FromForm] OpeningHoursUpdateDto model)
        {
            return await _openingHoursService.UpdateAsync(id, model);
        }



        #region Documentation
        /// <summary>
        ///  OpeningHours silinməsi
        /// </summary>
        /// <param name="id"></param>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Response))]
        #endregion
        [HttpDelete("Delete")]
        public async Task<Response> DeleteAsync(int id)
        {
            return await _openingHoursService.DeleteAsync(id);
        }



        #region Documentation
        /// <summary>
        ///  OpeningHours id parametrinə görə götürülməsi üçün
        /// </summary>
        /// <param name="id"></param>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<OpeningHoursResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Response))]
        #endregion
        [HttpGet("GetById")]
        public async Task<Response<OpeningHoursResponseDto>> GetAsync(int id)
        {
            return await (_openingHoursService.GetAsync(id));
        }



        #region Documentation
        /// <summary>
        /// OpeningHours siyahısını götürmək üçün
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<List<OpeningHoursResponseDto>>))]
        #endregion
        [HttpGet()]
        public async Task<Response<List<OpeningHoursResponseDto>>> GetAllAsync([FromQuery] string? search)
        {
            return await _openingHoursService.GetAllAsync(search);
        }
    }
}
