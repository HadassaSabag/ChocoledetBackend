using App.BL.Interfaces;
using App.DTO.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersItemsController : ControllerBase
    {
        private IOrderItemService _orderItemService;
        public OrdersItemsController(IOrderItemService ordersItemsService)
        {
            _orderItemService = ordersItemsService;
        }
        [HttpGet("{id}")]
        public async Task<List<OrderItemDTO>> GetOrderItemsById(Guid id)
        {
            try
            {
                return await _orderItemService.GetOrderItemsById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
