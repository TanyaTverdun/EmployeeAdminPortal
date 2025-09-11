using Microsoft.AspNetCore.Mvc;
using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.Models;
using EmployeeAdminPortal.Models.Entities;

namespace EmployeeAdminPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public EmployeesController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var allEmployees = this._dbContext.Employees.ToList();

            return Ok(allEmployees);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetEmployeeById(Guid id)
        {
            var employee = this._dbContext.Employees.Find(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpPost]
        public IActionResult AddEmployee(AddEmploeeDto addEmploeeDto)
        {
            var employeeEntity = new Employee()
            {
                Name = addEmploeeDto.Name,
                Email = addEmploeeDto.Email,
                Phone = addEmploeeDto.Phone,
                Salary = addEmploeeDto.Salary
            };

            this._dbContext.Employees.Add(employeeEntity);
            this._dbContext.SaveChanges();

            return Ok(employeeEntity);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateEmployee(Guid id, UpdateEmployeeDto updateEmployeeDto)
        {
            var existingEmployee = this._dbContext.Employees.Find(id);

            if (existingEmployee == null)
            {
                return NotFound();
            }

            existingEmployee.Name = updateEmployeeDto.Name;
            existingEmployee.Email = updateEmployeeDto.Email;
            existingEmployee.Phone = updateEmployeeDto.Phone;
            existingEmployee.Salary = updateEmployeeDto.Salary;

            this._dbContext.SaveChanges();

            return Ok(existingEmployee);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var existingEmployee = this._dbContext.Employees.Find(id);

            if (existingEmployee == null)
            {
                return NotFound();
            }

            this._dbContext.Employees.Remove(existingEmployee);
            this._dbContext.SaveChanges();

            return Ok(existingEmployee);
        }
    }
}
