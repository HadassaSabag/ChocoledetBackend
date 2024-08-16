using App.BL.Interfaces;
using App.BL.Mappers;
using App.DAL.Interfaces;
using App.DTO.Models;


namespace App.BL.Services
{
    public class CategoryService: ICategoryService
    {
        public ICategoriesRepository categories;
        public CategoryService(ICategoriesRepository categoriesRepository)
        {
            categories = categoriesRepository;
        }
        public async Task<CategoryDTO> GetCategoryById(int id)
        {
            try
            {
                var category = await categories.GetCategoryById(id);
                return CategoryMapper.Map(category);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
