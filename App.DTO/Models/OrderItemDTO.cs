

namespace App.DTO.Models
{
    public class OrderItemDTO
    {
        public Guid OrderItemId { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public virtual OrderDTO Order { get; set; } = null!;
        public virtual ProductDTO Product { get; set; } = null!;
    }
}
