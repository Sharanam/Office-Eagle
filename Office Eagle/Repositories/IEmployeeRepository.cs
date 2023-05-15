using Office_Eagle.DTOs;

namespace Office_Eagle.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeDTO>> GetEmployees();
        Task<EmployeeDTO> GetEmployee(int employeeId);
        Task<EmployeeDTO> AddEmployee(EmployeeDTO employee);
        Task<EmployeeDTO> UpdateEmployee(EmployeeDTO employee);
        Task<EmployeeDTO> DeleteEmployee(int employeeId);
    }
}
