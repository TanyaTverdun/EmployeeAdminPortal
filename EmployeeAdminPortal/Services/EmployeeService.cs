using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.Interfaces.Services;
using EmployeeAdminPortal.Models.Inputs;
using EmployeeAdminPortal.Models.Outputs;
using EmployeeAdminPortal.Models.Entities;
using Microsoft.EntityFrameworkCore;
using EmployeeAdminPortal.Extensions;
using EmployeeAdminPortal.Interfaces.Validators;

namespace EmployeeAdminPortal.Services
{
    public class EmployeeService : IEmployeesService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IEmployeeValidator _employeeValidator;

        public EmployeeService(ApplicationDbContext dbContext, IEmployeeValidator employeeValidator)
        {
            this._dbContext = dbContext;
            this._employeeValidator = employeeValidator;
        }

        public async Task AddEmployeeAsync(AddEmployeeInput input)
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
        }

        public async Task<DeleteEmployeeOutput> DeleteEmployeeAsync(DeleteEmployeeInput input)
        {
            Employee? existingEmployee = await this._employeeValidator.ValidateAndGetEmployeeAsync(input.EmployeeId);

            if (existingEmployee == null)
            {
                return new DeleteEmployeeOutput
                {
                    Employee = null
                };
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
            Employee? employee = await this._employeeValidator.ValidateAndGetEmployeeAsync(input.EmployeeId);

            return new GetEmployeeOutput
            {
                Employee = employee
            };
        }

        public async Task<UpdateEmployeeOutput> UpdateEmployeeAsync(UpdateEmployeeInput input)
        {
            Employee? existingEmployee = await this._employeeValidator.ValidateAndGetEmployeeAsync(input.Employee.EmployeeId);

            if (existingEmployee == null)
            {
                return new UpdateEmployeeOutput
                {
                    Employee = null
                };
            }

            existingEmployee.CopyFrom(input.Employee);

            await this._dbContext.SaveChangesAsync();

            return new UpdateEmployeeOutput
            {
                Employee = existingEmployee
            };
        }
    }
}
