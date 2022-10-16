using EFNewAPI.Models;
using EFNewAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EFNewAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_categoryService.Get());
        }

        [HttpPost]
        public IActionResult Post([FromBody] Category category)
        {
            return Ok(_categoryService.Add(category));
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, [FromBody] Category category)
        {
            return Ok(_categoryService.Update(id, category));
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            return Ok(_categoryService.Delete(id));
        }
    }
}
