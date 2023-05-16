using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using Office_Eagle.Data;
using Office_Eagle.DTOs;
using Office_Eagle.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Office_Eagle.Repositories
{
    public class DbAuthRepository : IAuthRepository
    {
        private readonly OfficeEagleDbContext _dbContext;
        private readonly IMapper _mapper;
         private readonly IConfiguration _configuration;
        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["AppSettings:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(int.Parse(_configuration["AppSettings:TokenExpirationDurationMinutes"])),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        public DbAuthRepository(OfficeEagleDbContext dbContext, IMapper mapper, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _configuration = configuration;
        }

        Task<ReadEmployeeDTO> IAuthRepository.Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        Task<User> IAuthRepository.Register(User user, string password)
        {
            throw new NotImplementedException();
        }

        Task<bool> IAuthRepository.UserExists(string username)
        {
            throw new NotImplementedException();
        }

        Task<ReadEmployeeDTO> IAuthRepository.GetUser(string username)
        {
            throw new NotImplementedException();
        }

        Task<ReadEmployeeDTO> IAuthRepository.GetUserById(Guid id)
        {
            throw new NotImplementedException();
        }

        Task<ReadEmployeeDTO> IAuthRepository.UpdateUser(UpdateUserDTO updateUserDTO)
        {
            throw new NotImplementedException();
        }

        Task<ReadEmployeeDTO> IAuthRepository.UpdatePassword(UpdatePasswordDTO updatePasswordDTO)
        {
            throw new NotImplementedException();
        }

        Task<bool> IAuthRepository.DeleteUser(Guid id)
        {
            throw new NotImplementedException();
        }

        Task<List<ReadEmployeeDTO>> IAuthRepository.GetAllUsers()
        {
            throw new NotImplementedException();
        }

        Task<List<ReadEmployeeDTO>> IAuthRepository.GetAllManagers()
        {
            throw new NotImplementedException();
        }

        Task<List<ReadEmployeeDTO>> IAuthRepository.GetAllEmployees()
        {
            throw new NotImplementedException();
        }

        Task<List<ReadEmployeeDTO>> IAuthRepository.GetAllAdmins()
        {
            throw new NotImplementedException();
        }

        Task<List<ReadEmployeeDTO>> IAuthRepository.GetAllEmployeesUnderManager(Guid managerId)
        {
            throw new NotImplementedException();
        }

        string IAuthRepository.GenerateJwtToken(ReadEmployeeDTO user)
        {
            throw new NotImplementedException();
        }
    }
}
