using Microsoft.AspNetCore.Mvc;
using Office_Eagle.DTOs;

namespace Office_Eagle.Repositories
{
    public interface IEmployeeRepository
    {
        Task<ReadEmployeeDTO> GetEmployee(Guid employeeId);
        Task<CreateEmployeeDTO> AddEmployee(CreateEmployeeDTO employee);
        Task<UpdateEmployeeDTO> UpdateEmployee(UpdateEmployeeDTO employee);
        Task<ReadEmployeeDTO> DeleteEmployee(Guid employeeId);
        Task<IActionResult> GetEmployees();
    }
}
