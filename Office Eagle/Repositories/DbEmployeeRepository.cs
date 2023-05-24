using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Office_Eagle.Data;
using Office_Eagle.DTOs;
using Office_Eagle.Models;
using Office_Eagle.Services;

namespace Office_Eagle.Repositories
{
    public class DbEmployeeRepository : IEmployeeRepository
    {
        private readonly OfficeEagleDbContext _dbContext;
        private readonly IMapper _mapper;

        public DbEmployeeRepository(OfficeEagleDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        private bool EmployeeExists(Guid id, string username = "", string employeeID = "")
        {
            return _dbContext.Users.Any(
                e => e.Id == id || e.Username == username || e.EmployeeID == employeeID
            );
        }

        async Task<CreateEmployeeDTO> IEmployeeRepository.AddEmployee(CreateEmployeeDTO employee)
        {
            User user = _mapper.Map<User>(employee);
            if (EmployeeExists(user.Id, user.Username, user.EmployeeID))
            {
                throw new Exception("Employee already exists");
            }
            if (!string.IsNullOrEmpty(employee.Password))
            {
                user.Password = PasswordGuardian.HashPassword(employee.Password);
            }
            user.CreatedAt = DateTime.Now;
            user.UpdatedAt = DateTime.Now;
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
            employee = _mapper.Map<CreateEmployeeDTO>(user);
            return (employee);
        }

        async Task<IActionResult> IEmployeeRepository.GetEmployees()
        {
            IEnumerable<User> users = await _dbContext.Users.ToListAsync();
            IEnumerable<ReadEmployeeDTO> employees = _mapper.Map<IEnumerable<ReadEmployeeDTO>>(
                users
            );
            return new OkObjectResult(employees);
        }

        async Task<ReadEmployeeDTO> IEmployeeRepository.DeleteEmployee(Guid employeeId)
        {
            User? user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == employeeId);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();

            ReadEmployeeDTO deletedEmployee = _mapper.Map<ReadEmployeeDTO>(user);
            return deletedEmployee;
        }

        async Task<ReadEmployeeDTO> IEmployeeRepository.GetEmployee(Guid employeeId)
        {
            User? user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == employeeId);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            ReadEmployeeDTO employeeDto = _mapper.Map<ReadEmployeeDTO>(user);
            return employeeDto;
        }

        async Task<UpdateEmployeeDTO> IEmployeeRepository.UpdateEmployee(UpdateEmployeeDTO employee)
        {
            User user = _mapper.Map<User>(employee);
            User? userInDb = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == employee.Id);

            if (userInDb == null)
            {
                throw new Exception("User not found");
            }

            _dbContext.Entry(userInDb).CurrentValues.SetValues(user);
            await _dbContext.SaveChangesAsync();

            UpdateEmployeeDTO updatedEmployee = _mapper.Map<UpdateEmployeeDTO>(user);
            return updatedEmployee;
        }
    }
}
