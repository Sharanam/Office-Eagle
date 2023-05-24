using Microsoft.AspNetCore.Mvc;
using Office_Eagle.Repositories;
using Office_Eagle.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace Office_Eagle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        private readonly IConfiguration _configuration;

        public AuthController(IAuthRepository authRepository, IConfiguration configuration)
        {
            _authRepository = authRepository;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            try
            {
                var user = await _authRepository.Login(loginDTO.Username, loginDTO.Password);
                Console.WriteLine("User: " + user);
                if (user == null)
                {
                    return Unauthorized();
                }
                return Ok(new { token = _authRepository.GenerateJwtToken(user) });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.Message);
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDTO registerDTO)
        {
            try
            {
                if (await _authRepository.UserExists(registerDTO.Username))
                {
                    return BadRequest("Username already exists");
                }
                return Ok(await _authRepository.Register(registerDTO));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("user-exists/{username}")]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> UserExists(string username)
        {
            return Ok(await _authRepository.UserExists(username));
        }

        [HttpGet("get-user/{username}")]
        public async Task<IActionResult> GetUser(string username)
        {
            return Ok(await _authRepository.GetUser(username));
        }

        [HttpGet("get-user-by-id/{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            return Ok(await _authRepository.GetUserById(id));
        }

        [HttpPut("update-user")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDTO updateUserDTO)
        {
            return Ok(await _authRepository.UpdateUser(updateUserDTO));
        }

        [HttpPut("update-password")]
        public async Task<IActionResult> UpdatePassword(
            [FromBody] UpdatePasswordDTO updatePasswordDTO
        )
        {
            return Ok(await _authRepository.UpdatePassword(updatePasswordDTO));
        }

        [HttpDelete("delete-user/{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            return Ok(await _authRepository.DeleteUser(id));
        }

        [HttpGet("get-all-users")]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await _authRepository.GetAllUsers());
        }

        [HttpGet("get-all-managers")]
        public async Task<IActionResult> GetAllManagers()
        {
            return Ok(await _authRepository.GetAllManagers());
        }

        [HttpGet("get-all-employees")]
        public async Task<IActionResult> GetAllEmployees()
        {
            return Ok(await _authRepository.GetAllEmployees());
        }

        [HttpGet("get-all-admins")]
        public async Task<IActionResult> GetAllAdmins()
        {
            return Ok(await _authRepository.GetAllAdmins());
        }

        [HttpGet("get-all-employees-under-manager/{managerId}")]
        public async Task<IActionResult> GetAllEmployeesUnderManager(Guid managerId)
        {
            return Ok(await _authRepository.GetAllEmployeesUnderManager(managerId));
        }
    }
}
