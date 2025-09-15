using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.Interfaces.Services;
using EmployeeAdminPortal.Models.Inputs;
using EmployeeAdminPortal.Models.Outputs;
using EmployeeAdminPortal.Models.Entities;
using Microsoft.EntityFrameworkCore;

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
            Employee newEmployee = new Employee()
            {
                EmployeeId = Guid.NewGuid(),
                Name = input.Name,
                Email = input.Email,
                Phone = input.Phone,
                Salary = input.Salary,
                IsDeleted = false
            };

            await this._dbContext.Employees.AddAsync(newEmployee);
            await this._dbContext.SaveChangesAsync();

            return new AddEmployeeOutput
            {
                Employee = newEmployee
            };
        }

        public async Task<DeleteEmployeeOutput?> DeleteEmployeeAsync(DeleteEmployeeInput input)
        {
            Employee? existingEmployee = await this._dbContext.Employees
                .FirstOrDefaultAsync(
                e => e.EmployeeId == input.EmployeeId
                && !e.IsDeleted);

            if (existingEmployee == null)
            {
                return null;
            }

            existingEmployee.IsDeleted = true;
            await this._dbContext.SaveChangesAsync();

            return new DeleteEmployeeOutput
            {
                Employee = existingEmployee
            };
        }

        public async Task<GetAllEmployeesOutput> GetAllEmployeesAsync()
        {
            List<Employee> employees = await this._dbContext.Employees.Where(e => !e.IsDeleted).ToListAsync();

            return new GetAllEmployeesOutput
            {
                Employees = employees
            };
        }

        public async Task<GetEmployeeOutput> GetEmployeeByIdAsync(GetEmployeeInput input)
        {
            Employee? employee = await this._dbContext.Employees
                .FirstOrDefaultAsync(
                e => e.EmployeeId == input.EmployeeId
                && !e.IsDeleted);

            return new GetEmployeeOutput
            {
                Employee = employee
            };
        }

        public async Task<UpdateEmployeeOutput?> UpdateEmployeeAsync(UpdateEmployeeInput input)
        {
            Employee? existingEmployee = await this._dbContext.Employees
                .FirstOrDefaultAsync(
                e => e.EmployeeId == input.EmployeeId
                && !e.IsDeleted);

            if (existingEmployee == null)
            {
                return null;
            }

            existingEmployee.Name = input.Name;
            existingEmployee.Email = input.Email;
            existingEmployee.Phone = input.Phone;
            existingEmployee.Salary = input.Salary;

            await this._dbContext.SaveChangesAsync();

            return new UpdateEmployeeOutput
            {
                Employee = existingEmployee
            };
        }
    }
}
