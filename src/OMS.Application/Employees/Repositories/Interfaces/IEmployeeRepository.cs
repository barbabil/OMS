using OMS.Domain.Employees;

namespace OMS.Application.Employees.Repositories.Interfaces;

public interface IEmployeeRepository
{
    public Task<Employee?> GetEmployeeById(int employeeId);

    public Task<bool> SaveEmployee(Employee employee);
}