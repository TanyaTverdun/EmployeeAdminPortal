using EmployeeAdminPortal.Models.Inputs;
using EmployeeAdminPortal.Models.Outputs;
using EmployeeAdminPortal.Employees.UpdateEmployee.Dtos;
using Riok.Mapperly.Abstractions;
using EmployeeAdminPortal.Models.Entities;

namespace EmployeeAdminPortal.Employees.UpdateEmployee
{
    [Mapper]
    public static partial class UpdateEmployeeMapper
    {
        public static UpdateEmployeeInput MapToInput(Guid EmployeeId, UpdateEmployeeRequest request)
        {
            var input = MapFromDto(request);
            input.Employee.EmployeeId = EmployeeId;

            return input;
        }
        private static partial UpdateEmployeeInput MapFromDto(UpdateEmployeeRequest request);


        [MapperIgnoreTarget(nameof(Employee.IsDeleted))]
        [MapperIgnoreTarget(nameof(Employee.EmployeeId))]
        private static partial Employee MapEmployeeDtoToEmployee(EmployeeDto employee);
    }
}
