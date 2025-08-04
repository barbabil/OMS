using FluentValidation;

namespace OMS.Application.Orders.Commands.AssignOrder;

public class AssignOrderCommandValidator : AbstractValidator<AssignOrderCommand>
{
    //Validation rules for assigning an order to an employee that will deliver it
}