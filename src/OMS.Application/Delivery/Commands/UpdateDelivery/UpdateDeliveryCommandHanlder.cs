using CSharpFunctionalExtensions;
using OMS.Application.Employees.Repositories.Interfaces;
using OMS.Application.Orders.Repositories.Interfaces;
using OMS.Application.Shared.Commands.Interfaces;
using OMS.Domain.Shared;

namespace OMS.Application.Delivery.Commands.UpdateDelivery;

public class UpdateDeliveryCommandHanlder : ICommandHandler<UpdateDeliveryCommand, Result<bool, Error>>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IOrdersReadRepository _ordersReadRepository;
    private readonly IOrdersWriteRepository _ordersWriteRepository;

    public UpdateDeliveryCommandHanlder(IOrdersReadRepository ordersReadRepository,
                                        IOrdersWriteRepository ordersWriteRepository,
                                        IEmployeeRepository employeeRepository)
    {
        _ordersReadRepository = ordersReadRepository;
        _ordersWriteRepository = ordersWriteRepository;
        _employeeRepository = employeeRepository;
    }

    public async Task<Result<bool, Error>> Handle(UpdateDeliveryCommand command,
                                                  CancellationToken cancellationToken)
    {
        // Fetch the order by ID
        //var order = await _ordersReadRepository.GetOrderById(Guid.NewGuid()) as DeliveryOrder;

        // Fetch the employee by ID
        //var employee = await _employeeRepository.GetEmployeeById(111);

        // progress the delivery based on the new status given
        //order.ProgressDelivery("Delivered");

        // save the order
        //_ordersWriteRepository.SaveOrder(order);

        // if status is Delivered or Unable to Deliver, then unassign the delivery from the employee
        //order.UnassignFromEmployee(employee)

        // save the employee

        return true;
    }
}