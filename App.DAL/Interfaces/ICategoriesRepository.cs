using App.DAL.Entities;


namespace App.DAL.Interfaces
{
    public interface ICategoriesRepository
    {
        public Task<Category> GetCategoryById(int id);
    }
}
