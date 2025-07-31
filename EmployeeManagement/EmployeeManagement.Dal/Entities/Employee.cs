using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Dal.Entities;

public class Employee
{
    public long EmployeeId { get; set; }
    public string FullName { get; set; } = null!;
    public string Position { get; set; } = null!;
    public decimal Salary { get; set; }
    public DateTime HiredDate { get; set; }
}
