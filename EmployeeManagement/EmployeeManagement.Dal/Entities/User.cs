using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;


namespace EmployeeManagement.Dal.Entities;
public class User 
{
    public long UserId { get; set; }
    public string Username { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public UserRole Role { get; set; } // Admin, HR, Employee
    public string Position { get; set; } = null!;
    public decimal Salary { get; set; }
}
public enum UserRole
{
    Admin,
    HR,
    Employee
}