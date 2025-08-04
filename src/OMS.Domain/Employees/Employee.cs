using Ardalis.GuardClauses;
using CSharpFunctionalExtensions;
using OMS.Domain.Orders;
using OMS.Domain.Shared;

namespace OMS.Domain.Employees;

public class Employee : Entity<int>
{
    private List<Order> _assignedOrders = new();

    private Employee(FirstName firstName,
                    LastName lastName,
                    Address address,
                    MobilePhoneNumber mobilePhoneNumber,
                    Email email,
                    Vat vat,
                    Role role)
    {
        FirstName = firstName;
        LastName = lastName;
        Address = address;
        MobilePhoneNumber = mobilePhoneNumber;
        Email = email;
        Vat = vat;
        EmployeeRole = role;
    }

    public enum Role
    {
        Manager,
        Staff,
        Chef,
        Delivery
    }

    public Address Address { get; private set; }

    public Email Email { get; private set; }

    public Role EmployeeRole { get; private set; }

    public FirstName FirstName { get; private set; }

    public LastName LastName { get; private set; }

    public MobilePhoneNumber MobilePhoneNumber { get; private set; }

    public Vat Vat { get; private set; }

    public static Result<Employee, Error> Instantiate(FirstName firstName,
                                                    LastName lastName,
                                                    Address address,
                                                    MobilePhoneNumber mobilePhoneNumber,
                                                    Email email,
                                                    Vat vat,
                                                    Role role)
    {
        // first name cannot be null
        Guard.Against.Null(firstName, nameof(firstName));
        // last name cannot be null
        Guard.Against.Null(lastName, nameof(lastName));
        // address cannot be null
        Guard.Against.Null(address, nameof(address));
        // mobilePhoneNumber cannot be null
        Guard.Against.Null(mobilePhoneNumber, nameof(mobilePhoneNumber));
        // email cannot be null
        Guard.Against.Null(email, nameof(email));
        // vat cannot be null
        Guard.Against.Null(vat, nameof(vat));
        // role cannot be null
        Guard.Against.Null(role, nameof(role));

        return new Employee(firstName, lastName, address, mobilePhoneNumber, email, vat, role);
    }

    public Result<bool, Error> AssignOrder(Order order)
    {
        // order cannot be null
        Guard.Against.Null(order, nameof(order));

        // check if the order is already assigned to this employee
        if (_assignedOrders.Contains(order))
            return Result.Failure<bool, Error>(new Error("OrderAlreadyAssigned", "This order is already assigned to this employee."));

        _assignedOrders.Add(order);

        return true;
    }

    public Result<bool, Error> UnassignOrder(Order order)
    {
        // order cannot be null
        Guard.Against.Null(order, nameof(order));

        // check if the order is assigned to this employee
        if (!_assignedOrders.Contains(order))
            return Result.Failure<bool, Error>(new Error("OrderNotAssigned", "This order is not assigned to this employee."));

        _assignedOrders.Remove(order);
        return true;
    }
}