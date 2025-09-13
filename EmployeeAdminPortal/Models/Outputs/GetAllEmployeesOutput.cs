using EmployeeAdminPortal.Models.Entities;

namespace EmployeeAdminPortal.Models.Outputs
{
    public class GetAllEmployeesOutput
    {
        public List<Employee> Employees { get; set; } = null!;
    }
}
