using EmployeeAdminPortal.Models.Inputs;
using EmployeeAdminPortal.Models.Outputs;
using EmployeeAdminPortal.Employees.DeleteEmployee.Dtos;

namespace EmployeeAdminPortal.Employees.DeleteEmployee
{
    public static class DeleteEmployeeMapper
    {
        public static DeleteEmployeeInput MapToInput(DeleteEmployeeRequest request)
        {
            return new DeleteEmployeeInput
            {
                EmployeeId = request.EmployeeId
            };
        }

        public static DeleteEmployeeResponse MapToResponse(DeleteEmployeeOutput output)
        {
            if (output.Employee is null)
            {
                throw new ArgumentNullException(nameof(output), "The 'Employee' property of the output cannot be null.");
            }

            return new DeleteEmployeeResponse
            {
                Employee = new EmployeeDto
                {
                    EmployeeId = output.Employee.EmployeeId,
                    Name = output.Employee.Name,
                    Email = output.Employee.Email,
                    Phone = output.Employee.Phone,
                    Salary = output.Employee.Salary
                }
            };
        }
    }
}
