using App.DAL.Entities;
using App.DTO.Models;


namespace App.BL.Mappers
{
    internal static class OrderItemMapper
    {
        internal static OrderItem Map(OrderItemDTO orderItem)
        {
            return new OrderItem
            {
                OrderItemId=orderItem.OrderItemId,
                OrderId=orderItem.OrderId,
                ProductId=orderItem.ProductId,
                Quantity=orderItem.Quantity,
            };
        }
        internal static OrderItemDTO Map(OrderItem orderItem)
        {
            return new OrderItemDTO
            {
                OrderItemId = orderItem.OrderItemId,
                OrderId = orderItem.OrderId,
                ProductId = orderItem.ProductId,
                Quantity = orderItem.Quantity,
            };
        }
    }
}
