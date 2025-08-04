namespace OMS.Application.Orders.Commands.AssignOrder;

public record AssignOrderRequest
{
    public int EmployeeId { get; set; }
}