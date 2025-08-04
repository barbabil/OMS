using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OMS.Application.Menu.Commands.AddMenuItem;
using OMS.Application.Menu.Commands.RemoveMenuItem;
using OMS.Application.Menu.Commands.UpdateMenuItem;
using OMS.Application.Menu.Queries.GetMenuItems;

namespace OMS.WebApi.Menu;

[ApiController]
[Authorize(Roles = "Admins")]
[Route("api/v1/menu-items")]
public class MenuItemsController : ControllerBase
{
    protected readonly IMediator Mediator;

    public MenuItemsController(IMediator mediator)
    {
        Mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] AddMenuItemRequest request)
    {
        var result = await Mediator.Send(new AddMenuItemCommand(request));

        if (result.IsFailure)
            return BadRequest(result.Error);

        return Created(string.Empty, result.Value);
    }

    [HttpPut("{menuItemId:int}")]
    public async Task<IActionResult> Edit(int menuItemId, [FromBody] UpdateMenuItemRequest request)
    {
        var result = await Mediator.Send(new UpdateMenuItemCommand(request));

        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok(result.Value);
    }

    [HttpGet]
    public async Task<IActionResult> GetMenuItems([FromQuery] GetMenuItemsRequest request)
    {
        var result = await this.Mediator.Send(new GetMenuItemsQuery(request));

        return Ok(result);
    }

    [HttpDelete("{menuItemId:int}")]
    public async Task<IActionResult> Remove(int menuItemId)
    {
        var result = await Mediator.Send(new RemoveMenuItemCommand(menuItemId));

        if (result.IsFailure)
            return BadRequest(result.Error);

        return Ok(result.Value);
    }
}