using App.BL.Interfaces;
using App.BL.Mappers;
using App.DAL.Entities;
using App.DAL.Interfaces;
using App.DTO.Models;


namespace App.BL.Services
{
    public class ProductService: IProductService
    {
        public IProductsRepository products;
        public ProductService(IProductsRepository productsRepository)
        {
            products = productsRepository;
        }
        public async Task<ProductDTO> GetProductById(Guid id)
        {
            try
            {
            var product = await products.GetProductById(id);
            return  ProductMapper.Map(product);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<ProductDTO>> GetProducts()
        {
            try
            {
            List<Product> productList = await products.GetProducts();
            return productList.Select(u => ProductMapper.Map(u)).ToList();  
            }
            catch (Exception ex)
            {
                throw ex;
            }  
        }
        public async Task<Guid> CreateProduct(ProductDTO product)
        {
            try
            {
            return await products.CreateProduct(ProductMapper.Map(product));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
