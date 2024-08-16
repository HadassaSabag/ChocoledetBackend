using App.DAL.DataContext;
using App.DAL.Entities;
using App.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace App.DAL.Repositories
{
    public class OrdersRepository: IOrdersRepository
    {
        public ChocoledetContext dbContext;
        public OrdersRepository(ChocoledetContext chocoledetContext)
        {
            dbContext = chocoledetContext;
        }
        public async Task<List<Order>> GetOrdersById(Guid id)
        {
            try
            {
            List<Order> orders = await dbContext.Orders.Where(u => u.UserId == id).Include(o => o.OrderItems).ToListAsync();
            return  orders;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        public async Task<Guid> CreateOrder(Order order)
        {
            try
            {
            await dbContext.Orders.AddAsync(order);
            foreach (var item in order.OrderItems)
            await dbContext.OrderItems.AddAsync(item);
            await dbContext.SaveChangesAsync();
            return order.OrderId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

    }
}
