using Application.UseCases.Categories;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly GetAllCategory _getAllCategory;
        private readonly GetCategoryById _getCategoryById;
        private readonly AddCategory _addCategory;
        private readonly UpdateCategory _updateCategory;
        private readonly DeleteCategory _deleteCategory;

        public CategoryController(GetAllCategory Category, GetCategoryById categoryById, AddCategory addCategory,
                                    UpdateCategory updateCategory,DeleteCategory deleteCategory)
        {
            _getAllCategory = Category;
            _getCategoryById = categoryById;
            _addCategory = addCategory;
            _updateCategory = updateCategory;
            _deleteCategory = deleteCategory;
            
        }



        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<IEnumerable<Category>> GetAllCategory()
        {
            return  await _getAllCategory.Execute();
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategoryById(int id)
        {
            var category = await _getCategoryById.Exucte(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory([FromBody] Category category)
        {
            await _addCategory.Execute(category);
            return CreatedAtAction(nameof(GetCategoryById), new { id = category.Id_category }, category);
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutCategory(int id, [FromBody] Category category)
        {
            if (id != category.Id_category)
            {
                return BadRequest();
            }

            await _updateCategory.Execute(category);
            return NoContent();
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            await _deleteCategory.Execute(id);
            return NoContent();
        }
    }
}
