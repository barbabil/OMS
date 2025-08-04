using CSharpFunctionalExtensions;
using OMS.Application.Shared.Commands.Interfaces;
using OMS.Domain.Shared;

namespace OMS.Application.Orders.Commands.AssignOrder;

public record AssignOrderCommand : ICommand<Result<bool, Error>>
{
    public AssignOrderCommand(Guid orderId, int employeeId)
    {
        OrderId = orderId;
        EmployeeId = employeeId;
    }
    public Guid OrderId { get; }
    public int EmployeeId { get; }
}