using App.DAL.Entities;


namespace App.DAL.Interfaces
{
    public interface IOrdersItemsRepository
    {
        public Task<List<OrderItem>> GetOrderItemsById(Guid id);
    }
}
