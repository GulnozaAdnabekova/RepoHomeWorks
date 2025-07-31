using EmployeeManagement.Dal;
using EmployeeManagement.Dal.Entities;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly MainContext MainContext;

    public EmployeeRepository(MainContext mainContext)
    {
        MainContext = mainContext;
    }


    public async Task<long> InsertAsync(Employee employee)
    {
        await MainContext.Employees.AddAsync(employee);
        await MainContext.SaveChangesAsync();
        return employee.EmployeeId;
    }

    public Task<ICollection<Employee>> SelectAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<Employee>> SelectByUserIdAsync(long userId)
    {
        throw new NotImplementedException();
    }

    public Task<Employee?> UpdateAsync(Employee employee)
    {
        throw new NotImplementedException();
    }
    public Task<long> DeleteAsync(long employeeId)
    {
        throw new NotImplementedException();
    }
}
