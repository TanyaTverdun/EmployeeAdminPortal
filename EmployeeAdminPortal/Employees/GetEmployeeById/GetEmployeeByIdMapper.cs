using EmployeeAdminPortal.Models.Inputs;
using EmployeeAdminPortal.Models.Outputs;
using EmployeeAdminPortal.Employees.GetEmployeeById.Dtos;

namespace EmployeeAdminPortal.Employees.GetEmployeeById
{
    public static class GetEmployeeByIdMapper
    {
        public static GetEmployeeInput MapToInput(GetEmployeeByIdRequest request)
        {
            return new GetEmployeeInput
            {
                EmployeeId = request.EmployeeId,
            };
        }

        public static GetEmployeeByIdResponse MapToResponse(GetEmployeeOutput output)
        {
            if (output.Employee == null)
            {
                return new GetEmployeeByIdResponse { Employee = null };
            }

            return new GetEmployeeByIdResponse
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
