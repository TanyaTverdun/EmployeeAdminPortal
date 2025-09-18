using EmployeeAdminPortal.Models.Inputs;
using EmployeeAdminPortal.Models.Outputs;
using EmployeeAdminPortal.Employees.GetEmployeeById.Dtos;
using Riok.Mapperly.Abstractions;
using EmployeeAdminPortal.Models.Entities;

namespace EmployeeAdminPortal.Employees.GetEmployeeById
{
    [Mapper]
    public static partial class GetEmployeeByIdMapper
    {
        public static partial GetEmployeeByIdResponse MapToResponse(GetEmployeeOutput output);
        
        [MapperIgnoreSource(nameof(Employee.IsDeleted))]
        [MapperIgnoreSource(nameof(Employee.EmployeeId))]
        private static partial EmployeeDto MapEmployeeToDto(Employee employee);
    }
}
