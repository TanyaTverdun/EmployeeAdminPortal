using EmployeeAdminPortal.Employees.AddEmployee.Dtos;
using EmployeeAdminPortal.Models.Inputs;
using EmployeeAdminPortal.Models.Outputs;

namespace EmployeeAdminPortal.Employees.AddEmployee
{
    public static class AddEmployeeMapper
    {
        public static AddEmployeeInput MapToInput(AddEmployeeRequest request)
        {
            return new AddEmployeeInput
            {
                Name = request.Employee.Name,
                Email = request.Employee.Email,
                Phone = request.Employee.Phone,
                Salary = request.Employee.Salary,
            };
        }

        public static AddEmployeeResponse MapToResponse(AddEmployeeOutput output)
        {
            return new AddEmployeeResponse
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
