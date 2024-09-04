using App.DAL.Entities;


namespace App.DAL.Interfaces
{
    public interface IOrdersRepository
    {
        public Task<List<Order>> GetOrdersByUserId(Guid id);
        public Task<Guid> CreateOrder(Order order);
    }
}
