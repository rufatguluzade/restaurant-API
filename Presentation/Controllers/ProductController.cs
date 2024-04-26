using Business.DTOs.Common;
using Business.DTOs.Product.Request;
using Business.DTOs.Product.Response;
using Business.Services.Abstraction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }



        #region Documentation
        /// <summary>
        /// Product siyahısını götürmək üçün
        /// </summary>
        /// <remarks>
        /// <ul>
        ///  <li><b>Type:</b> 0 - Standart, 1 - Yeni, 2 - Satılmış, 3 - Satışda</li>
        /// </ul>
        /// </remarks>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<List<ProductResponseDto>>))]
        #endregion


        [HttpGet()]
       // [Authorize(Roles = "User,Admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        public async Task<Response<List<ProductResponseDto>>> GetAllAsync(string? search)
        {
            return await _productService.GetAllAsync(search);
        }



        #region Documentation
        /// <summary>
        ///  Product id parametrinə görə götürülməsi üçün
        /// </summary>
        /// <param name="id"></param>
      
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<ProductResponseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Response))]
        #endregion
        [HttpGet("GetById")]
       // [Authorize(Roles = "User,Admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        public async Task<Response<ProductResponseDto>> GetAsync(int id)
        {
            return await _productService.GetAsync(id);
        }

        #region Documentation
        /// <summary>
        /// Product yaradılması üçün
        /// </summary>
        /// <param name="model"></param>
     
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Response))]
        #endregion
        [HttpPost("Create")]
      //  [Authorize(Roles = "Admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        public async Task<Response> CreateAsync([FromForm] ProductCreateDto model)
        {
            return await _productService.CreateAsync(model);
        }

        #region Documentation
        /// <summary>
        /// Product redaktə olunması üçün
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
      
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Response))]
        #endregion
        [HttpPut("Update")]
     //   [Authorize(Roles = "Admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        public async Task<Response> UpdateAsync(int id, [FromForm] ProductUpdateDto model)
        {
            return await _productService.UpdateAsync(id, model);
        }

        #region Documentation
        /// <summary>
        ///  Product silinməsi
        /// </summary>
        /// <param name="id"></param>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Response))]
        #endregion
        [HttpDelete("Delete")]
       // [Authorize(Roles = "Admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        public async Task<Response> DeleteAsync(int id)
        {
            return await _productService.DeleteAsync(id);
        }
    }
}
