using EmployeeAdminPortal.Models.Outputs;
using EmployeeAdminPortal.Employees.GetAllEMployees.Dtos;

namespace EmployeeAdminPortal.Employees.GetAllEMployees
{
    public static class GetAllEmployeesMapper
    {
        public static GetAllEmployeesResponse MapToResponse(GetAllEmployeesOutput output)
        {
            return new GetAllEmployeesResponse
            {
                Employees = output.Employees.Select(e => new EmployeeDto
                {
                    EmployeeId = e.EmployeeId,
                    Name = e.Name,
                    Email = e.Email,
                    Phone = e.Phone,
                    Salary = e.Salary
                }).ToList()
            };
        }
    }
}
