using App.BL.Interfaces;
using App.BL.Mappers;
using App.DAL.Entities;
using App.DAL.Interfaces;
using App.DTO.Models;


namespace App.BL.Services
{
    public class OrderService: IOrderService
    {
        public IOrdersRepository orders;
        public IOrdersItemsRepository ordersItems;
        public OrderService(IOrdersRepository ordersRepository)
        {
            orders = ordersRepository;
        }
        public List<OrderDTO> GetOrdersById(Guid id)
        {
            List<Order> orderList = orders.GetOrdersById(id);
            return orderList.Select(u => OrderMapper.Map(u)).ToList();
        }
        public Guid CreateOrder(OrderDTO order)
        {
            return orders.CreateOrder(OrderMapper.Map(order));
        }
    }
}
