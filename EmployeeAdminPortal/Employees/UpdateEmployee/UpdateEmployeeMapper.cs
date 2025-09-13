using EmployeeAdminPortal.Models.Inputs;
using EmployeeAdminPortal.Models.Outputs;
using EmployeeAdminPortal.Employees.UpdateEmployee.Dtos;

namespace EmployeeAdminPortal.Employees.UpdateEmployee
{
    public static class UpdateEmployeeMapper
    {
        public static UpdateEmployeeInput MapToInput(Guid EmployeeId, UpdateEmployeeRequest request)
        {
            return new UpdateEmployeeInput
            {
                EmployeeId = EmployeeId,
                Name = request.Employee.Name,
                Email = request.Employee.Email,
                Phone = request.Employee.Phone,
                Salary = request.Employee.Salary
            };
        }

        public static UpdateEmployeeResponse MapToResponse(UpdateEmployeeOutput output)
        {
            if (output.Employee is null)
            {
                throw new ArgumentNullException(nameof(output), "The 'Employee' property of the output cannot be null.");
            }

            return new UpdateEmployeeResponse
            {
                Employee = new EmployeeDto
                {
                    Name = output.Employee.Name,
                    Email = output.Employee.Email,
                    Phone = output.Employee.Phone,
                    Salary = output.Employee.Salary
                }
            };
        }
    }
}
