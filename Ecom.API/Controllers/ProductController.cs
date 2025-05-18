using AutoMapper;
using Ecom.API.Helper;
using Ecom.Core.DTO.Product;
using Ecom.Core.Interfaces;
using Ecom.Core.Sharing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Ecom.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork work;
        private readonly IMapper map;

        public ProductController( IUnitOfWork work , IMapper map)
        {
            this.work = work;
            this.map = map;
        }
        [HttpGet]
        [EndpointSummary("Get All Details about Products")]
        public async Task<IActionResult> GetAllAsync([FromQuery] ProductParams productParams)
        {
            try
            {
                 var products = await  work.productRepository.GetAllAsync(productParams);
                var totalCount = await work.productRepository.CountAsync();

                return Ok(new Pagination<ProductDTO>(productParams.pageNumber , productParams.MaxPageSize,totalCount,products));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
               
            }
        }
        [HttpGet("{id}")]
        [EndpointSummary("Get All Product Details")]

        public async Task<IActionResult> GetBYId(int id)
        {
            try
            {
                var product = await work.productRepository.GetByIdWithIncludesAsync(id,  x => x.category , x => x.Photos);
                var result=  map.Map<ProductDTO>(product);
                if (result == null)
                    return NotFound("Product not found");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
          
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Add([FromForm]AddProductDTO productDTO)
        {
            try
            {
                await work.productRepository.AddAsync(productDTO);
                return Ok(productDTO);
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        [HttpPut]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Update( [FromForm]UpdateProductDTO updateProductDTO)
        {
            try
            {
                await work.productRepository.UpdateAsync(updateProductDTO);
                return Ok(updateProductDTO);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var product = await work.productRepository.GetByIdWithIncludesAsync(id, x => x.category, x => x.Photos);
                if (product == null)
                    return NotFound("Product not found");
                await work.productRepository.DeleteAsync(product);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
