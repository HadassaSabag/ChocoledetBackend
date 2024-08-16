using App.DTO.Models;

namespace App.BL.Interfaces
{
    public interface IOrderItemService
    {
        public List<OrderItemDTO> GetOrderItemsById(Guid id);

    }
}
