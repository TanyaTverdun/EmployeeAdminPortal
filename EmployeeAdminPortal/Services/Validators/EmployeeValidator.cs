using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.Interfaces.Validators;
using EmployeeAdminPortal.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAdminPortal.Services.Validators
{
    public class EmployeeValidator : IEmployeeValidator
    {
        private readonly ApplicationDbContext _dbContext;

        public EmployeeValidator(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Employee?> ValidateAndGetEmployeeAsync(Guid employeeId)
        {
            var employee = await _dbContext.Employees
                .FirstOrDefaultAsync(e => e.EmployeeId == employeeId && !e.IsDeleted);

            return employee;
        }
    }
}
