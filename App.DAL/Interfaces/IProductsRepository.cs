using App.DAL.Entities;


namespace App.DAL.Interfaces
{
    public interface IProductsRepository
    {
        public Product GetProductById(Guid id);
        public List<Product> GetProducts();
        public Guid CreateProduct(Product product);

    }
}
