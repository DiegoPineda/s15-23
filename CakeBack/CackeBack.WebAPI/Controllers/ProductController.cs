using CackeBack.BLL.Interfaces;
using CakeBack.Models.VModels.CategoryDTO;
using CakeBack.Models.VModels.SubCategoryDTO;
using Microsoft.AspNetCore.Mvc;

namespace CackeBack.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // Category Endpoints
        [HttpGet("categories")]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _productService.GetAllCategoriesAsync();
            return Ok(categories);
        }

        [HttpGet("categories/{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _productService.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost("categories")]
        public async Task<IActionResult> CreateCategory(CategoryCreationDTO category)
        {
            CategoryDTO createdCategory = await _productService.AddCategoryAsync(category);
            return CreatedAtAction(nameof(GetCategoryById), new { id = createdCategory.Id }, createdCategory);
        }

        [HttpPut("categories/{id}")]
        public async Task<IActionResult> UpdateCategory(int id, CategoryCreationDTO category)
        {
            try
            {
                await _productService.UpdateCategoryAsync(id, category);
            }
            catch (Exception)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("categories/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _productService.DeleteCategoryAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        // SubCategory Endpoints
        [HttpGet("subcategories")]
        public async Task<IActionResult> GetAllSubCategories()
        {
            var subCategories = await _productService.GetAllSubCategoriesAsync();
            return Ok(subCategories);
        }

        [HttpGet("subcategories/{id}")]
        public async Task<IActionResult> GetSubCategoryById(int id)
        {
            var subCategory = await _productService.GetSubCategoryByIdAsync(id);
            if (subCategory == null)
            {
                return NotFound();
            }
            return Ok(subCategory);
        }

        [HttpPost("subcategories")]
        public async Task<IActionResult> CreateSubCategory(SubCategoryCreationDTO subCategory)
        {
            SubCategoryDTO createdSubCategory = await _productService.AddSubCategoryAsync(subCategory);
            return CreatedAtAction(nameof(GetSubCategoryById), new { id = createdSubCategory.Id }, createdSubCategory);
        }

        [HttpPut("subcategories/{id}")]
        public async Task<IActionResult> UpdateSubCategory(int id, SubCategoryCreationDTO subCategory)
        {
            try
            {
                await _productService.UpdateSubCategoryAsync(id, subCategory);
            }
            catch (Exception)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("subcategories/{id}")]
        public async Task<IActionResult> DeleteSubCategory(int id)
        {
            var result = await _productService.DeleteSubCategoryAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}