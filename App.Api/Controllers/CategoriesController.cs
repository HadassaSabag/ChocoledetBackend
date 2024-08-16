using App.BL.Interfaces;
using App.DTO.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoriesService)
        {
            _categoryService = categoriesService;
        }
        [HttpGet("{id}")]
        public async Task<CategoryDTO> GetCategoryById(int id)
        {
            try
            {
            return await _categoryService.GetCategoryById(id);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
