using App.DAL.DataContext;
using App.DAL.Entities;
using App.DAL.Interfaces;


namespace App.DAL.Repositories
{
    public class CategoriesRepository:ICategoriesRepository
    {
        public ChocoledetContext dbContext;
        public CategoriesRepository(ChocoledetContext chocoledetContext)
        {
            dbContext = chocoledetContext;
        }
        public Category GetCategoryById(int id)
        {
            return dbContext.Categories.SingleOrDefault(u => u.CategoryId == id);
        }
    }
}
