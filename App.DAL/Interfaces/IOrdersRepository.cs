using App.DAL.Entities;


namespace App.DAL.Interfaces
{
    public interface IOrdersRepository
    {
        public List<Order> GetOrdersById(Guid id);
        public Guid CreateOrder(Order order);
    }
}
