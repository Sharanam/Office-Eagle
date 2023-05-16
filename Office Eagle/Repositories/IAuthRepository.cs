using Office_Eagle.DTOs;
using Office_Eagle.Models;

namespace Office_Eagle.Repositories
{
    public interface IAuthRepository
    {
        Task<ReadEmployeeDTO> Login(string username, string password);
        Task<User> Register(User user, string password);
        Task<bool> UserExists(string username);
        Task<ReadEmployeeDTO> GetUser(string username);
        Task<ReadEmployeeDTO> GetUserById(Guid id);
        Task<ReadEmployeeDTO> UpdateUser(UpdateUserDTO updateUserDTO);
        Task<ReadEmployeeDTO> UpdatePassword(UpdatePasswordDTO updatePasswordDTO);
        Task<bool> DeleteUser(Guid id);
        Task<List<ReadEmployeeDTO>> GetAllUsers();

        Task<List<ReadEmployeeDTO>> GetAllManagers();
        Task<List<ReadEmployeeDTO>> GetAllEmployees();
        Task<List<ReadEmployeeDTO>> GetAllAdmins();
        Task<List<ReadEmployeeDTO>> GetAllEmployeesUnderManager(Guid managerId);

        string GenerateJwtToken(ReadEmployeeDTO user);

    }
}
