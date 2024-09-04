using App.DAL.Entities;
using App.DTO.Models;


namespace App.BL.Mappers
{
    internal static class UserMapper
    {
        internal static User Map(UserDTO user)
        {
            return new User
            {
                UserId = user.UserId,
                UserName = user.UserName,
                Email = user.Email,
                Password = user.Password,
                CreatedAt = user.CreatedAt,
                IsDeleted = user.IsDeleted,
                Phone = user.Phone,
                Orders = user.Orders.Select(item => new Order
                {
                    OrderId = item.OrderId,
                    UserId = item.UserId,
                    OrderDate = item.OrderDate,
                    TotalAmount = item.TotalAmount,
                    PaymentStatus = item.PaymentStatus,
                    OrderItems = item.OrderItems.Select(item => new OrderItem
                    {
                        OrderItemId = item.OrderItemId,
                        ProductId = item.ProductId,
                        OrderId = item.OrderId,
                        Quantity = item.Quantity
                    }).ToList()
                }).ToList()
            };
        }
        internal static UserDTO Map(User user)
        {
            return new UserDTO
            {
                UserId = user.UserId,
                UserName = user.UserName,
                Email = user.Email,
                Password = user.Password,
                CreatedAt = user.CreatedAt,
                IsDeleted = user.IsDeleted,
                Phone = user.Phone,
                Orders = user.Orders.Select(item => new OrderDTO
                {
                    OrderId = item.OrderId,
                    UserId = item.UserId,
                    OrderDate = item.OrderDate,
                    TotalAmount = item.TotalAmount,
                    PaymentStatus = item.PaymentStatus,
                    OrderItems = item.OrderItems.Select(item => new OrderItemDTO
                    {
                        OrderItemId = item.OrderItemId,
                        ProductId = item.ProductId,
                        OrderId = item.OrderId,
                        Quantity = item.Quantity
                    }).ToList()
                }).ToList()
            };
        }
    }
}