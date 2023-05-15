using Office_Eagle.DTOs;

namespace Office_Eagle.Repositories
{
    public class DbEmployeeRepository : IEmployeeRepository
    {
        Task<EmployeeDTO> IEmployeeRepository.AddEmployee(EmployeeDTO employee)
        {
            throw new NotImplementedException();
        }

        Task<EmployeeDTO> IEmployeeRepository.DeleteEmployee(int employeeId)
        {
            throw new NotImplementedException();
        }

        Task<EmployeeDTO> IEmployeeRepository.GetEmployee(int employeeId)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<EmployeeDTO>> IEmployeeRepository.GetEmployees()
        {
            return Task.FromResult<IEnumerable<EmployeeDTO>>(
                new List<EmployeeDTO>() { new EmployeeDTO() }
            );
        }

        Task<EmployeeDTO> IEmployeeRepository.UpdateEmployee(EmployeeDTO employee)
        {
            throw new NotImplementedException();
        }
    }
}
