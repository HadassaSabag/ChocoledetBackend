using App.Api.Models;

public class OrderRequest
{
    public Guid UserId { get; set; }
    public bool PaymentStatus { get; set; }
    public virtual ICollection<OrderItemRequest> OrderItems { get; set; } = new List<OrderItemRequest>();

}
