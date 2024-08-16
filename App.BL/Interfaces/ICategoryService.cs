using App.DTO.Models;


namespace App.BL.Interfaces
{
    public interface ICategoryService
    {
        public CategoryDTO GetCategoryById(int id);

    }
}
