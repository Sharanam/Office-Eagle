using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using Office_Eagle.Data;
using Office_Eagle.DTOs;
using Office_Eagle.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Office_Eagle.Services;

namespace Office_Eagle.Repositories
{
    public class DbAuthRepository : IAuthRepository
    {
        private readonly OfficeEagleDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        string IAuthRepository.GenerateJwtToken(User user)
        {
            var key = Encoding.ASCII.GetBytes(_configuration["Authentication:Key"]);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Name, user.Username),
                        new Claim(ClaimTypes.Role, user.Role.ToString())
                    }
                ),
                Expires = DateTime.UtcNow.AddMinutes(
                    int.Parse(
                        _configuration["Authentication:TokenExpirationDurationMinutes"] ?? "60"
                    )
                ),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha512Signature
                )
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public DbAuthRepository(
            OfficeEagleDbContext dbContext,
            IMapper mapper,
            IConfiguration configuration
        )
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _configuration = configuration;
        }

        async Task<User> IAuthRepository.Login(string username, string password)
        {
            // User? user = _dbContext.Users.FirstOrDefault(x => x.Username == username);
            User? user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Username == username);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            if (!PasswordGuardian.VerifyPassword(password, user.Password))
            {
                throw new Exception("Incorrect password");
            }

            return (user);
        }

        async Task<User> IAuthRepository.Register(RegisterUserDTO registeringUser)
        {
            User user = _mapper.Map<User>(registeringUser);
            if (await ((IAuthRepository)this).UserExists(user.Username))
            {
                throw new Exception("Username already exists");
            }

            user.Password = PasswordGuardian.HashPassword(user.Password);
            user.CreatedAt = DateTime.Now;
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        async Task<bool> IAuthRepository.UserExists(string username)
        {
            return await _dbContext.Users.AnyAsync(x => x.Username == username);
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
    }
}
