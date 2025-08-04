using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OMS.Application.Orders.Commands.PlaceOrder;
using OMS.Application.Orders.Queries.GetOrderStatus;

namespace OMS.WebApi.Orders;

[ApiController]
[Authorize(Roles = "Buyers")]
[Route("api/v1/orders")]
public class OrderController : ControllerBase
{
    protected readonly IMediator Mediator;

    public OrderController(IMediator mediator)
    {
        Mediator = mediator;
    }

    // GET: api/v1/orders/{orderId}/status
    [HttpGet("{orderId:Guid}/status")]
    public async Task<IActionResult> GetOrderStatus([FromQuery] Guid orderId)
    {
        var result = await this.Mediator.Send(new GetOrderStatusQuery(orderId));

        return Ok(result);
    }

    // POST: api/v1/orders
    [HttpPost]
    public async Task<IActionResult> PlaceOrder([FromBody] PlaceOderRequest request)
    {
        var result = await Mediator.Send(new PlaceOrderCommand(request));

        if (result.IsFailure)
            return BadRequest(result.Error);

        return Created(string.Empty, result.Value);
    }
}