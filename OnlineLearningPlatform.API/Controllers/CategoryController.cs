using Microsoft.AspNetCore.Mvc;
using OnlineLearningPlatform.API.Models;
using OnlineLearningPlatform.Core.Service;

namespace OnlineLearningPlatform.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService _categoryService)
        {
            categoryService = _categoryService;
        }

        [HttpGet]
        public ActionResult<List<Category>> GetAll()
        {
            return Ok(categoryService.GetAllCategories());
        }

        [HttpGet("{id}")]
        public ActionResult<Category> GetById(int id)
        {
            var category = categoryService.GetCategoryById(id);
            if (category == null) return NotFound();
            return Ok(category);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Category category)
        {
            categoryService.CreateCategory(category);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] Category category)
        {
            categoryService.UpdateCategory(category);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            categoryService.DeleteCategory(id);
            return Ok();
        }
    }
}