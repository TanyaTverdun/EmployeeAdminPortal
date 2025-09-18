using EmployeeAdminPortal.Employees.AddEmployee.Dtos;
using EmployeeAdminPortal.Models.Entities;
using EmployeeAdminPortal.Models.Inputs;
using EmployeeAdminPortal.Models.Outputs;
using Riok.Mapperly.Abstractions;

namespace EmployeeAdminPortal.Employees.AddEmployee
{
    [Mapper]
    public static partial class AddEmployeeMapper
    {
        [MapProperty("Employee.Name", "Name")]
        [MapProperty("Employee.Email", "Email")]
        [MapProperty("Employee.Phone", "Phone")]
        [MapProperty("Employee.Salary", "Salary")]
        public static partial AddEmployeeInput MapToInput(AddEmployeeRequest request);
    }
}
