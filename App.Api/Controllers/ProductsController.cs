using App.Api.Mappers;
using App.Api.Models;
using App.BL.Interfaces;
using App.DTO.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductService _productService;
        public ProductsController(IProductService productsService)
        {
            _productService = productsService;
        }
        [HttpGet("{id}")]
        public async Task<ProductDTO> GetProductById(Guid id)
        {
            try
            {
            return await _productService.GetProductById(id);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        public async Task<List<ProductDTO>> GetProducts()
        {
            try
            {
            return await _productService.GetProducts();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        public async Task<Guid> CreateProduct(ProductRequest product)
        {
            try
            {
            return await _productService.CreateProduct(ProductMapper.Map(product));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
