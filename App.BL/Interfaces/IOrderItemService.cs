using App.DTO.Models;

namespace App.BL.Interfaces
{
    public interface IOrderItemService
    {
        public Task<List<OrderItemDTO>> GetOrderItemsById(Guid id);

    }
}
