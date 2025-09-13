using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.Interfaces.Services;
using EmployeeAdminPortal.Models.Entities;

namespace EmployeeAdminPortal.Services
{
    public class EmployeeService : IEmployeesService
    {
        private readonly ApplicationDbContext _dbContext;

        public EmployeeService(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<AddEmployeeOutput> AddEmployeeAsync(AddEmployeeInput input)
        {
            throw new NotImplementedException();
        }

        public async Task<DeleteEmployeeOutput?> DeleteEmployeeAsync(DeleteEmployeeInput input)
        {
            throw new NotImplementedException();
        }

        public async Task<GetAllEmployeesOutput> GetAllEmployeesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<GetEmployeeOutput> GetEmployeeByIdAsync(GetEmployeeInput input)
        {
            throw new NotImplementedException();
        }

        public async Task<UpdateEmployeeOutput?> UpdateEmployeeAsync(UpdateEmployeeInput input)
        {
            throw new NotImplementedException();
        }
    }
}
