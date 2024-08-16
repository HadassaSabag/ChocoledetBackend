using App.DTO.Models;


namespace App.BL.Interfaces
{
    public interface ICategoryService
    {
        public Task<CategoryDTO> GetCategoryById(int id);

    }
}
