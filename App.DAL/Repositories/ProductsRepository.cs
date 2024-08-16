using App.DAL.DataContext;
using App.DAL.Entities;
using App.DAL.Interfaces;


namespace App.DAL.Repositories
{
    public class ProductsRepository: IProductsRepository
    {
        public ChocoledetContext dbContext;
        public ProductsRepository(ChocoledetContext chocoledetContext)
        {
            dbContext = chocoledetContext;
        }
        public Product GetProductById(Guid id)
        {
            return dbContext.Products.SingleOrDefault(u => u.ProductId == id);
        }
        public List<Product> GetProducts()
        {
            return dbContext.Products.ToList();
        }
        public Guid CreateProduct(Product product)
        {
            dbContext.Products.Add(product);
            dbContext.SaveChanges();
            return (Guid)product.ProductId;
        }
    }
}
