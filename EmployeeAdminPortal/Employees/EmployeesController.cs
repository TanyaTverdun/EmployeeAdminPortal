using Microsoft.AspNetCore.Mvc;
using EmployeeAdminPortal.Employees.AddEmployee;
using EmployeeAdminPortal.Employees.DeleteEmployee;
using EmployeeAdminPortal.Employees.GetAllEmployees;
using EmployeeAdminPortal.Employees.GetEmployeeById;
using EmployeeAdminPortal.Employees.UpdateEmployee;
using EmployeeAdminPortal.Interfaces.Services;

namespace EmployeeAdminPortal.Employees
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeesService _employeesService;

        public EmployeesController(IEmployeesService employeesService)
        {
            this._employeesService = employeesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var output = await this._employeesService.GetAllEmployeesAsync();

            var response = GetAllEmployeesMapper.MapToResponse(output);

            return Ok(response);

        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetEmployeeById(Guid id)
        {
            var request = new GetEmployeeByIdRequest
            {
                EmployeeId = id
            };

            var input = GetEmployeeByIdMapper.MapToInput(request);

            var output = await this._employeesService.GetEmployeeByIdAsync(input);

            var response = GetEmployeeByIdMapper.MapToResponse(output);

            if (response.Employee == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] AddEmployeeRequest request)
        {
            var input = AddEmployeeMapper.MapToInput(request);

            var output = await this._employeesService.AddEmployeeAsync(input);

            var response = AddEmployeeMapper.MapToResponse(output);

            return Ok(response);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateEmployee(Guid id, [FromBody] UpdateEmployeeRequest request)
        {
            var input = UpdateEmployeeMapper.MapToInput(id, request);

            var output = await this._employeesService.UpdateEmployeeAsync(input);

            if (output == null || output.Employee == null)
            {
                return NotFound();
            }

            var response = UpdateEmployeeMapper.MapToResponse(output);

            return Ok(response);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            var request = new DeleteEmployeeRequest
            {
                EmployeeId = id
            };

            var input = DeleteEmployeeMapper.MapToInput(request);

            var output = await this._employeesService.DeleteEmployeeAsync(input);

            if (output == null || output.Employee == null)
            {
                return NotFound();
            }

            var response = DeleteEmployeeMapper.MapToResponse(output);

            return Ok(response);
        }
    }
}
