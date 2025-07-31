using EmployeeManagement.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.BLL.Dtos.UserDto;

public class UserCreateDto
{
    public string Username { get; set; } = null!;
    public string PasswordHash { get; set; }    
    public UserRole Role { get; set; } // Admin, HR, Employee
    public string Position { get; set; } = null!;
    public decimal Salary { get; set; }
}
