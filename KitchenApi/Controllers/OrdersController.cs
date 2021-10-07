using System;
using System.Threading;
using System.Threading.Tasks;
using KitchenApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace KitchenApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly ICookingService _cookingService;

        public OrdersController(ICookingService cookingService)
        {
            _cookingService = cookingService;
        }

        [HttpPost("{orderId:guid}")]
        public async Task<IActionResult> AcceptOrder([FromRoute] Guid orderId, CancellationToken token)
        {
            await _cookingService.PrepareOrderAsync(orderId, token);
            return Ok();
        }
    }
}