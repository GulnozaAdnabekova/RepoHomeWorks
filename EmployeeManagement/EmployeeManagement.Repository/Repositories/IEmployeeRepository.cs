using EmployeeManagement.Dal.Entities;

namespace EmployeeManagement.Repository.Repositories;

public interface IEmployeeRepository
{
    Task<long> InsertAsync(Employee employee);
    Task<ICollection<Employee>> SelectAllAsync();
    Task<ICollection<Employee>> SelectByUserIdAsync(long userId);
    Task<Employee?> UpdateAsync(Employee employee);
    Task<long> DeleteAsync(long employeeId);

}
