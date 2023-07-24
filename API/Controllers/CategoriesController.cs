using Application.Models;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("{id}", Name = "Get")]
        [ProducesResponseType(typeof(CategoryModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _categoryService.GetCategoryById(id));
        }
    }
}