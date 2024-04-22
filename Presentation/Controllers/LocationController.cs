using Business.DTOs.Common;
using Business.DTOs.RestaurantLocations.Location.Request;
using Business.DTOs.RestaurantLocations.Location.Response;
using Business.Services.Abstraction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {

        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        #region Documentation
        /// <summary>
        /// Locations yaradılması üçün
        /// </summary>
        /// <param name="model"></param>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Response))]
        #endregion
        [HttpPost("Create")]
        // [Authorize(Roles = "Admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        public async Task<Response> CreateAsync([FromBody] LocationCreateDto model)
        {
            return await _locationService.CreateAsync(model);
        }


        #region Documentation
        /// <summary>
        /// Locations redakte etmek üçün
        /// </summary>
        /// <param name="model"></param>
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Response))]
        #endregion
        [HttpPut("Update")]
        public async Task<Response> UpdateAsync(int id, [FromBody] LocationUpdateDto model)
        {
            return await _locationService.UpdateAsync(id, model);
        }



        #region Documentation
        /// <summary>
        ///  Locations silinməsi
        /// </summary>
        /// <param name="id"></param>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Response))]
        #endregion
        [HttpDelete("Delete")]
        public async Task<Response> DeleteAsync(int id)
        {
            return await _locationService.DeleteAsync(id);
        }



        #region Documentation
        /// <summary>
        ///  Locations id parametrinə görə götürülməsi üçün
        /// </summary>
        /// <param name="id"></param>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<LocationResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Response))]
        #endregion
        [HttpGet("GetById")]
        public async Task<Response<LocationResponseDto>> GetAsync(int id)
        {
            return await (_locationService.GetAsync(id));
        }



        #region Documentation
        /// <summary>
        /// Locations siyahısını götürmək üçün
        /// </summary>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<List<LocationResponseDto>>))]
        #endregion
        [HttpGet()]
        public async Task<Response<List<LocationResponseDto>>> GetAllAsync([FromQuery] string? search)
        {
            return await _locationService.GetAllAsync(search);
        }
    }
}
