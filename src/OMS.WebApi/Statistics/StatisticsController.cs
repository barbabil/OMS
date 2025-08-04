using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OMS.Application.Menu.Queries.GetMenuItems;

namespace OMS.WebApi.Statistics;

[ApiController]
[Authorize(Roles = "Admins")]
[Route("api/v1/statistics")]
public class StatisticsController : ControllerBase
{
    protected readonly IMediator Mediator;

    public StatisticsController(IMediator mediator)
    {
        Mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAverageOrderFullfilmentTime([FromQuery] GetMenuItemsRequest request)
    {
        var result = await this.Mediator.Send(new GetMenuItemsQuery(request));

        return Ok(result);
    }
}