using App.Api.Mappers;
using App.BL.Interfaces;
using App.DTO.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private IOrderService _orderService;
        public OrdersController(IOrderService ordersService)
        {
            _orderService = ordersService;
        }
        [HttpGet("{id}")]

        public async Task<List<OrderDTO>> GetOrdersById(Guid id)
        {
            try
            {
            return await _orderService.GetOrdersById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public async Task<Guid> CreateOrder(OrderRequest order)
        {
            try
            {
            return await _orderService.CreateOrder(OrderMapper.Map(order));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
