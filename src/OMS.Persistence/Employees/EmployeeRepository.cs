using OMS.Application.Employees.Repositories.Interfaces;
using OMS.Domain.Employees;

namespace OMS.Persistence.Employees;

public class EmployeeRepository : IEmployeeRepository
{
    public async Task<Employee?> GetEmployeeById(int employeeId)
    {
        // Fetch an employee from the db

        return null;
    }

    public async Task<bool> SaveEmployee(Employee employee)
    {
        return true;
    }
}