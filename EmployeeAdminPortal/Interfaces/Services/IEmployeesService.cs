using EmployeeAdminPortal.Models.Outputs;
using EmployeeAdminPortal.Models.Inputs;

namespace EmployeeAdminPortal.Interfaces.Services
{
    public interface IEmployeesService
    {
        Task<GetAllEmployeesOutput> GetAllEmployeesAsync();
        Task<GetEmployeeOutput> GetEmployeeByIdAsync(GetEmployeeInput input);
        Task AddEmployeeAsync(AddEmployeeInput input);
        Task<UpdateEmployeeOutput> UpdateEmployeeAsync(UpdateEmployeeInput input);
        Task<DeleteEmployeeOutput> DeleteEmployeeAsync(DeleteEmployeeInput input);
    }
}
