using App.DTO.Models;


namespace App.BL.Interfaces
{
    public interface IProductService
    {
        public Task<ProductDTO> GetProductById(Guid id);
        public Task<List<ProductDTO>> GetProducts();
        public Task<Guid> CreateProduct(ProductDTO product);

    }
}
