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
        [MapProperty(nameof(AddEmployeeRequest.Employee.Name), nameof(AddEmployeeInput.Name))]
        [MapProperty(nameof(AddEmployeeRequest.Employee.Email), nameof(AddEmployeeInput.Email))]
        [MapProperty(nameof(AddEmployeeRequest.Employee.Phone), nameof(AddEmployeeInput.Phone))]
        [MapProperty(nameof(AddEmployeeRequest.Employee.Salary), nameof(AddEmployeeInput.Salary))]
        public static partial AddEmployeeInput MapToInput(AddEmployeeRequest request);
    }
}
