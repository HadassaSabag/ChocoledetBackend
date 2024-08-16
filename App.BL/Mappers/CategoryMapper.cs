using App.DAL.Entities;
using App.DTO.Models;


namespace App.BL.Mappers
{
    internal static class CategoryMapper
    {
        internal static Category Map(CategoryDTO category)
        {
            return new Category
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName
            };
        }
        internal static CategoryDTO Map(Category category)
        {
            return new CategoryDTO
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName
            };
        }
    }
}
