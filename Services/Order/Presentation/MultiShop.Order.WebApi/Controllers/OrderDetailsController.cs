using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;

namespace MultiShop.Order.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly GetOrderDetailQueryHandler _getOrderDetailQueryHandler;
        private readonly GetOrderDetailByIdQueryHandler _getOrderDetailByIdQueryHandler;
        private readonly CreateOrderDetailCommandHandler _createOrderDetailCommandHandler;
        private readonly RemoveOrderDetailCommandQueryHandler _removeOrderDetailCommandQueryHandler;
        private readonly UpdateOrderDetailCommandQueryHandler _updateOrderDetailCommandQueryHandler;

        public OrderDetailsController(GetOrderDetailQueryHandler getOrderDetailQueryHandler,
            GetOrderDetailByIdQueryHandler getOrderDetailByIdQueryHandler,
            CreateOrderDetailCommandHandler createOrderDetailCommandHandler,
            RemoveOrderDetailCommandQueryHandler removeOrderDetailCommandQueryHandler,
            UpdateOrderDetailCommandQueryHandler updateOrderDetailCommandQueryHandler)
        {
            _getOrderDetailQueryHandler = getOrderDetailQueryHandler;
            _getOrderDetailByIdQueryHandler = getOrderDetailByIdQueryHandler;
            _createOrderDetailCommandHandler = createOrderDetailCommandHandler;
            _removeOrderDetailCommandQueryHandler = removeOrderDetailCommandQueryHandler;
            _updateOrderDetailCommandQueryHandler = updateOrderDetailCommandQueryHandler;
        }
        [HttpGet]
        public async Task<IActionResult> OrderDetailList()
        {
            var values = await _getOrderDetailQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderDetailById(int id)
        {
            var value = await _getOrderDetailByIdQueryHandler.Handle(new GetOrderDetailByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrderDetail(CreateOrderDetailCommand command)
        {
            await _createOrderDetailCommandHandler.Handle(command);
            return Ok("Order elave olundu!");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveOrderDetail(int id)
        {
            await _removeOrderDetailCommandQueryHandler.Handle(new RemoveOrderDetailCommand(id));
            return Ok("Order silindi!");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailCommand command)
        {
            await _updateOrderDetailCommandQueryHandler.Handle(command);
            return Ok("Sifaris guncellendi!");
        }

    }
}
