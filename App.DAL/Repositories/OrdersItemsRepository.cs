using App.DAL.DataContext;
using App.DAL.Entities;
using App.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace App.DAL.Repositories
{
    public class OrdersItemsRepository: IOrdersItemsRepository
    {
        public ChocoledetContext dbContext;
        public OrdersItemsRepository(ChocoledetContext chocoledetContext)
        {
            dbContext = chocoledetContext;
        }
        public async Task<List<OrderItem>> GetOrderItemsById(Guid id)
        {
            try
            {
            List<OrderItem> orderItems =await dbContext.OrderItems.Where(u => u.OrderId == id).ToListAsync();
            return orderItems;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
