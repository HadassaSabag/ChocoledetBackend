using App.DTO.Models;


namespace App.BL.Interfaces
{
    public interface IOrderService
    {
        public List<OrderDTO> GetOrdersById(Guid id);
        public Guid CreateOrder(OrderDTO order);

    }
}
