

namespace App.DAL.Entities;

public partial class Order
{
    public Guid OrderId { get; set; }

    public Guid UserId { get; set; }

    public DateTime OrderDate { get; set; }

    public double TotalAmount { get; set; }

    public bool PaymentStatus { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual User User { get; set; } = null!;
}
