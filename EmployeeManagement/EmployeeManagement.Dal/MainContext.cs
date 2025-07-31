using EmployeeManagement.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Dal;

public class MainContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Employee> Employees { get; set; }

    public MainContext(DbContextOptions<MainContext> options) : base(options)
    {
    }
}
