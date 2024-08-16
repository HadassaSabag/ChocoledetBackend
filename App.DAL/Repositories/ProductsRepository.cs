using App.DAL.DataContext;
using App.DAL.Entities;
using App.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace App.DAL.Repositories
{
    public class ProductsRepository: IProductsRepository
    {
        public ChocoledetContext dbContext;
        public ProductsRepository(ChocoledetContext chocoledetContext)
        {
            dbContext = chocoledetContext;
        }
        public async Task<Product> GetProductById(Guid id)
        {
            try
            {
            return await dbContext.Products.SingleOrDefaultAsync(u => u.ProductId == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<Product>> GetProducts()
        {
            try
            {
            return await dbContext.Products.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Guid> CreateProduct(Product product)
        {
            try
            {
            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();
            return (Guid)product.ProductId;
            }
            catch (Exception ex)
            {
                throw ex;
            } 
        }
    }
}
