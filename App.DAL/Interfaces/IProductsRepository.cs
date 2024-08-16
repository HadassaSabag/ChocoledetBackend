using App.DAL.Entities;


namespace App.DAL.Interfaces
{
    public interface IProductsRepository
    {
        public Task<Product> GetProductById(Guid id);
        public Task<List<Product>> GetProducts();
        public Task<Guid> CreateProduct(Product product);

    }
}
