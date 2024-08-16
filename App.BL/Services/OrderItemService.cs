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
        public async Task<List<OrderItemDTO>> GetOrderItemsById(Guid id)
        {
            try
            {
            List <OrderItem> orderItemList=await ordersItem.GetOrderItemsById(id);
            return orderItemList.Select(u => OrderItemMapper.Map(u)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
