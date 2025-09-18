using EmployeeAdminPortal.Models.Outputs;
using EmployeeAdminPortal.Employees.GetAllEmployees.Dtos;
using Riok.Mapperly.Abstractions;
using EmployeeAdminPortal.Models.Entities;

namespace EmployeeAdminPortal.Employees.GetAllEmployees
{
    [Mapper]
    public static partial class GetAllEmployeesMapper
    {
        public static partial GetAllEmployeesResponse MapToResponse(GetAllEmployeesOutput output);

        [MapperIgnoreSource(nameof(Employee.IsDeleted))]
        private static partial EmployeeDto MapEmployeeToDto(Employee employee);
    }
}
