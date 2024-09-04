using App.DTO.Models;


namespace App.BL.Interfaces
{
    public interface IOrderService
    {
        public Task<List<OrderDTO>> GetOrdersByUserId(Guid id);
        public Task<Guid> CreateOrder(OrderDTO order);

    }
}
