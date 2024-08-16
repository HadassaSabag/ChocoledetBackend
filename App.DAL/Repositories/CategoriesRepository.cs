using App.DAL.DataContext;
using App.DAL.Entities;
using App.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace App.DAL.Repositories
{
    public class CategoriesRepository:ICategoriesRepository
    {
        public ChocoledetContext dbContext;
        public CategoriesRepository(ChocoledetContext chocoledetContext)
        {
            dbContext = chocoledetContext;
        }
        public async Task<Category> GetCategoryById(int id)
        {
            try
            {
            return await dbContext.Categories.SingleOrDefaultAsync(u => u.CategoryId == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
