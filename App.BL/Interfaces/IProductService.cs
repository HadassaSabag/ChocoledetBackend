using App.DTO.Models;


namespace App.BL.Interfaces
{
    public interface IProductService
    {
        public ProductDTO GetProductById(Guid id);
        public List<ProductDTO> GetProducts();
        public Guid CreateProduct(ProductDTO product);

    }
}
