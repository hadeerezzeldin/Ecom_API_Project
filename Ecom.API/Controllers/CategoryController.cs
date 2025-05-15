using Ecom.Core.DTO.Category;
using Ecom.Core.Interfaces;
using Ecom.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork work;

        public CategoryController(IUnitOfWork work)
        {
            this.work = work;
        }
        [HttpGet]
        [EndpointDescription("Get all categories")]
        public async Task <IActionResult> GetAll()
        {
            try
            {
                var category =   await work.categoryRepository.GetAllAsync();
                if (category == null)
                    return NotFound("No categories found");
                    return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
          
            
        }
        [HttpGet("{id}")]
        [EndpointDescription("Get category by id")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var category = await work.categoryRepository.GetByIdAsync(id);
                if (category == null)
                    return NotFound("Category not found");
                
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Add(CategoryDTO catDTO)
        {
            try
            {
                var category = new Category()
                {
                    CategoryName = catDTO.Name,
                   CategoryDescription = catDTO.Description
                };
                await work.categoryRepository.AddAsync(category);
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CategoryDTO catDTO)
        {
            try
            {
             var category = await work.categoryRepository.GetByIdAsync(id);
                if (category == null)
                    return NotFound("Category not found");
                category.CategoryName = catDTO.Name;
                category.CategoryDescription = catDTO.Description;
                await work.categoryRepository.UpdateAsync(category);
                return Ok(category);
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
                var category = await  work.categoryRepository.GetByIdAsync(id);
                if (category == null)
                    return NotFound("Category not found");
                await  work.categoryRepository.DeleteAsync(id);
                return Ok("Category deleted successfully");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}

