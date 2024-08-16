
using App.DTO.Models;

namespace App.Api.Mappers
{
    internal static class OrderMapper
    {
        internal static OrderDTO Map(OrderRequest order)
        {
            var newOrderId = Guid.NewGuid();
            return new OrderDTO
            {
                OrderId = newOrderId,
                UserId = order.UserId,
                OrderDate = DateTime.Now,
                PaymentStatus = order.PaymentStatus,
                OrderItems = order.OrderItems.Select(item => new OrderItemDTO
                {
                    OrderItemId= Guid.NewGuid(),
                    ProductId = item.ProductId,
                    OrderId = newOrderId, 
                    Quantity = item.Quantity
                }).ToList()
            };
        }
    }
}
