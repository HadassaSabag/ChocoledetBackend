

namespace App.DTO.Models
{
    public class ProductDTO
    {
        public Guid ProductId { get; set; }

        public string ProductName { get; set; } = null!;

        public int CategoryId { get; set; }

        public double Price { get; set; }

        public string? ImagePath { get; set; }

        public virtual CategoryDTO Category { get; set; } = null!;

        public virtual ICollection<OrderItemDTO> OrderItems { get; set; } = new List<OrderItemDTO>();
    }
}
