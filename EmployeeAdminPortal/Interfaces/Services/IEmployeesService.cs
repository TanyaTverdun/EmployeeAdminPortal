namespace EmployeeAdminPortal.Interfaces.Services
{
    public class IEmployeesService
    {
        Task<GetAllEmployeesOutput> GetAllEmployeesAsync();
        Task<GetEmployeeOutput> GetEmployeeByIdAsync(GetEmployeeInput input);
        Task<AddEmployeeOutput> AddEmployeeAsync(AddEmployeeInput input);
        Task<UpdateEmployeeOutput?> UpdateEmployeeAsync(UpdateEmployeeInput input);
        Task<DeleteEmployeeOutput?> DeleteEmployeeAsync(DeleteEmployeeInput input);
    }
}
