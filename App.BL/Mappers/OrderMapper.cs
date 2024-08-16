using App.DAL.Entities;
using App.DTO.Models;


namespace App.BL.Mappers
{
    internal static class OrderMapper
    {
        internal static Order Map(OrderDTO order)
        {
            return new Order
            {
                OrderId = order.OrderId,
                UserId = order.UserId,
                OrderDate = order.OrderDate,
                TotalAmount=order.TotalAmount,
                PaymentStatus = order.PaymentStatus,
                OrderItems = order.OrderItems.Select(item => new OrderItem
                {
                    OrderItemId = item.OrderItemId,
                    ProductId = item.ProductId,
                    OrderId = item.OrderId,
                    Quantity = item.Quantity
                }).ToList()
            };
        }
        internal static OrderDTO Map(Order order)
        {
            return new OrderDTO
            {
                OrderId = order.OrderId,
                UserId = order.UserId,
                OrderDate = order.OrderDate,
                TotalAmount = order.TotalAmount,
                PaymentStatus = order.PaymentStatus,
                OrderItems = order.OrderItems.Select(item => new OrderItemDTO
                {
                    OrderItemId = item.OrderItemId,
                    ProductId = item.ProductId,
                    OrderId = item.OrderId,
                    Quantity = item.Quantity
                }).ToList()
            };
        }
    }
}
