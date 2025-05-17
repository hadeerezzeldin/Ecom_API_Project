using AutoMapper;
using Ecom.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BugController : ControllerBase
    {
        private readonly IUnitOfWork work;
        private readonly IMapper map;

        public BugController(IUnitOfWork work , IMapper map)
        {
            this.work = work;
            this.map = map;
        }

        [HttpGet("Not-Found")]
        public  async  Task<ActionResult> GetNotFound()
        {
            var category =   await work.categoryRepository.GetByIdAsync(100);
            if (category == null)
                return NotFound();
            return Ok(category);
        }
        [HttpGet("Server-Error")]
        public async Task<ActionResult> GetServerError(int id)
        {
            var category = await work.categoryRepository.GetByIdAsync(100);
            category.CategoryName = "";
            return Ok(category);

        }
        [HttpGet("Bad-Request/{id}")]
        public async Task<ActionResult> GetBadRequest(int id)
        {
            var category = await work.categoryRepository.GetByIdAsync(id);
            return Ok();

        }
        [HttpGet("Bad-Request")]
        public async Task<ActionResult> GetBadRequest()
        {
            return BadRequest();

        }

    }
}
