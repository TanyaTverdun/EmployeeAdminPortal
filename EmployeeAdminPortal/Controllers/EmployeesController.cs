using Microsoft.AspNetCore.Http;
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
            var allEmployees = _dbContext.Employees.ToList();

            return Ok(allEmployees);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetEmployeeById(Guid id)
        {
            var employee = _dbContext.Employees.Find(id);

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

            _dbContext.Employees.Add(employeeEntity);
            _dbContext.SaveChanges();

            return Ok(employeeEntity);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateEmployee(Guid id, UpdateEmployeeDto updateEmployeeDto)
        {
            var existingEmployee = _dbContext.Employees.Find(id);

            if (existingEmployee == null)
            {
                return NotFound();
            }

            existingEmployee.Name = updateEmployeeDto.Name;
            existingEmployee.Email = updateEmployeeDto.Email;
            existingEmployee.Phone = updateEmployeeDto.Phone;
            existingEmployee.Salary = updateEmployeeDto.Salary;

            _dbContext.SaveChanges();

            return Ok(existingEmployee);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var existingEmployee = _dbContext.Employees.Find(id);

            if (existingEmployee == null)
            {
                return NotFound();
            }

            _dbContext.Employees.Remove(existingEmployee);
            _dbContext.SaveChanges();

            return Ok(existingEmployee);
        }
    }
}
