using CSharpFunctionalExtensions;
using OMS.Application.Employees.Repositories.Interfaces;
using OMS.Application.Orders.Repositories.Interfaces;
using OMS.Application.Shared.Commands.Interfaces;
using OMS.Domain.Shared;

namespace OMS.Application.Orders.Commands.AssignOrder;

public class AssignOrderCommandHandler : ICommandHandler<AssignOrderCommand, Result<bool, Error>>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IOrdersReadRepository _ordersReadRepository;
    private readonly IOrdersWriteRepository _ordersWriteRepository;

    public AssignOrderCommandHandler(IOrdersReadRepository ordersReadRepository,
                                     IOrdersWriteRepository ordersWriteRepository,
                                     IEmployeeRepository employeeRepository)
    {
        _ordersReadRepository = ordersReadRepository;
        _ordersWriteRepository = ordersWriteRepository;
        _employeeRepository = employeeRepository;
    }

    public async Task<Result<bool, Error>> Handle(AssignOrderCommand request,
                                                  CancellationToken cancellationToken)
    {
        // Fetch the employee by ID
        //var employee = await _employeeRepository.GetEmployeeById(request.EmployeeId);

        // Fetch the order by ID
        //var order = await _ordersReadRepository.GetOrderById(request.OrderId) as DeliveryOrder;

        //assign the order
        //order.AssignToEmployee(employee);

        //save the employee with the order
        //_employeeRepository.SaveEmployee(employee);

        return true;
    }
}