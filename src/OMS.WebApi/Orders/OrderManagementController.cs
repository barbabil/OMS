using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OMS.Application.Orders.Commands.AssignOrder;
using OMS.Application.Orders.Commands.CancelOrder;
using OMS.Application.Orders.Commands.ProgressOrder;
using OMS.Application.Orders.Queries.GetOrders;

namespace OMS.WebApi.Orders;

[ApiController]
[Authorize(Roles = "RestaurantStaff")]
[Route("api/v1/restaurant/staff/orders")]
public class OrderManagementController : ControllerBase
{
    protected readonly IMediator Mediator;

    public OrderManagementController(IMediator mediator)
    {
        Mediator = mediator;
    }

    [HttpPost("{orderId:Guid}/assign")]
    public async Task<IActionResult> AssignOrder(Guid orderId, [FromBody] AssignOrderRequest request)
    {
        var result = await Mediator.Send(new AssignOrderCommand(orderId, request.EmployeeId));

        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok(result.Value);
    }

    [HttpPost("{orderId:Guid}/cancel")]
    public async Task<IActionResult> CancelOrder(Guid orderId)
    {
        var result = await Mediator.Send(new CancelOrderCommand(orderId));

        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok(result.Value);
    }

    [HttpGet]
    public async Task<IActionResult> GetOrders([FromQuery] GetOrdersRequest request)
    {
        var result = await Mediator.Send(new GetOrdersQuery(request));

        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> ProgressOrder(Guid orderId)
    {
        var result = await Mediator.Send(new ProgressOrderCommand(orderId));

        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok(result.Value);
    }
}