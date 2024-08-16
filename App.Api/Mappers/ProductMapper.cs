using App.Api.Models;
using App.DTO.Models;

namespace App.Api.Mappers
{
    internal static class ProductMapper
    {
        internal static ProductDTO Map(ProductRequest productRequest)
        {
            return new ProductDTO
            {
                ProductId = Guid.NewGuid(),
                ProductName = productRequest.ProductName,
                CategoryId = productRequest.CategoryId,
                Price = productRequest.Price,
                ImagePath = productRequest.ImagePath,
            };
        }
    }
}
