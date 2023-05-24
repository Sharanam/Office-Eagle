using Microsoft.AspNetCore.Mvc;
using Office_Eagle.DTOs;
using Office_Eagle.Repositories;
using Office_Eagle.Services;

namespace Office_Eagle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                return await _employeeRepository.GetEmployees();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetEmployee(Guid id)
        {
            try
            {
                return Ok(await _employeeRepository.GetEmployee(id));
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeDTO employee)
        {
            try
            {
                employee.Password = PasswordGuardian.HashPassword(employee.Password);
                employee.CreatedAt = DateTime.Now;
                return Ok(await _employeeRepository.AddEmployee(employee));
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee([FromBody] UpdateEmployeeDTO employee)
        {
            try
            {
                employee.Password = PasswordGuardian.HashPassword(employee.Password);
                return Ok(await _employeeRepository.UpdateEmployee(employee));
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{employeeId}")]
        public async Task<IActionResult> DeleteEmployee(Guid employeeId)
        {
            try
            {
                return Ok(await _employeeRepository.DeleteEmployee(employeeId));
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
