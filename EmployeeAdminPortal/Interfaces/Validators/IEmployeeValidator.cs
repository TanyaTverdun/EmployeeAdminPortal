using EmployeeAdminPortal.Models.Entities;

namespace EmployeeAdminPortal.Interfaces.Validators
{
    public interface IEmployeeValidator
    {
        Task<Employee?> ValidateAndGetEmployeeAsync(Guid employeeId);
    }
}
