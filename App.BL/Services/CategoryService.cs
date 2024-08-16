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
        public CategoryDTO GetCategoryById(int id)
        {
            return CategoryMapper.Map(categories.GetCategoryById(id));
        }
    }

}
