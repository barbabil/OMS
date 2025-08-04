using OMS.Application.Shared;

namespace OMS.Application.Orders.Queries.GetOrders;

public record GetOrdersRequest
{
    public string? Status { get; set; }

    public CustomerTemplate? Customer { get; set; }
}