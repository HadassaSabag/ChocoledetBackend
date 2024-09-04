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
        public async Task<List<OrderDTO>> GetOrdersByUserId(Guid id)
        {
            try
            {
            List<Order> orderList = await orders.GetOrdersByUserId(id);
            return orderList.Select(u => OrderMapper.Map(u)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        public async Task<Guid> CreateOrder(OrderDTO order)
        {
            try
            {
            return await orders.CreateOrder(OrderMapper.Map(order));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
