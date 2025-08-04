using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OMS.Application.Delivery.Commands.UpdateDelivery;
using OMS.Application.Delivery.Queries.GetAssignments;

namespace OMS.WebApi.Delivery;

[ApiController]
[Authorize(Roles = "DeliveryStaff")]
[Route("api/v1/delivery/staff/orders")]
public class DeliveryManagementController : ControllerBase
{
    protected readonly IMediator Mediator;

    public DeliveryManagementController(IMediator mediator)
    {
        Mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAssignments([FromQuery] int employeeId)
    {
        var result = await Mediator.Send(new GetAssignmentsQuery(employeeId));

        return Ok(result);
    }

    [HttpPost("{orderId:guid}/status")]
    public async Task<IActionResult> UpdateStatus(Guid orderId, [FromBody] UpdateDeliveryRequest request)
    {
        var result = await Mediator.Send(new UpdateDeliveryCommand(request));

        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok(result.Value);
    }
}