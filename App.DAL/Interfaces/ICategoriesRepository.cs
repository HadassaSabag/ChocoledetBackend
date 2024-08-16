using App.DAL.Entities;


namespace App.DAL.Interfaces
{
    public interface ICategoriesRepository
    {
        public Category GetCategoryById(int id);
    }
}
