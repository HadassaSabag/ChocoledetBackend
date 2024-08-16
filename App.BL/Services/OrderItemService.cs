using App.BL.Interfaces;
using App.BL.Mappers;
using App.DAL.Entities;
using App.DAL.Interfaces;
using App.DTO.Models;


namespace App.BL.Services
{
    public class OrderItemService: IOrderItemService
    {
        public IOrdersItemsRepository ordersItem;
        public OrderItemService(IOrdersItemsRepository ordersItemsRepository)
        {
            ordersItem = ordersItemsRepository;
        }
        public List<OrderItemDTO> GetOrderItemsById(Guid id)
        {
            List <OrderItem> orderItemList= ordersItem.GetOrderItemsById(id);
            return orderItemList.Select(u => OrderItemMapper.Map(u)).ToList();
        }
    }
}
