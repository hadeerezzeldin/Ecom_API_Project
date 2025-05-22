using AutoMapper;
using Ecom.Core.Interfaces;
using Ecom.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        //private readonly IUnitOfWork work;
        private readonly ICartReository cartReository;

        public CartController(ICartReository cartReository)
        {
            this.cartReository = cartReository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var result = await cartReository.GetBasketAsync(id);
           if(result == null)
            {
                return Ok(new CartItem());
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Cart cart)
        {
            var result = await cartReository.UpdateBasketAsync(cart);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Cart cart)
        {
            var result = await cartReository.UpdateBasketAsync(cart);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await cartReository.DeleteBasketAsync(id);
            if (result)
                return Ok("Deleted");
            return BadRequest("Not Deleted");
        }
    }
}
