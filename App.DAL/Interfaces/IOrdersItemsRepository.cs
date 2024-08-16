using App.DAL.Entities;


namespace App.DAL.Interfaces
{
    public interface IOrdersItemsRepository
    {
        public List<OrderItem> GetOrderItemsById(Guid id);
    }
}
