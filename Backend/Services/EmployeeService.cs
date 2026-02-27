using Backend.DTOs;
using Backend.Middlewares;
using Backend.Models;
using Backend.Repositories.Interfaces;
using Backend.Services.Interfaces;

namespace Backend.Services
{
    public class EmployeeService(IEmployeeRepository repo) : IEmployeeService
    {
        private static EmployeeDto ToDto(Employee s) => new()
        {
            FirstName = s.FirstName,
            LastName = s.LastName,
            Email = s.Email,
            IsActive = s.IsActive,
            PolicyId = s.PolicyId
         
        };

        public async Task<IEnumerable<EmployeeDto>> GetAllAsync()
        {
            var employees = await repo.GetAllAsync();

            return employees.Select(ToDto);
        }
        public async Task<EmployeeDto?> GetByIdAsync(int id)
        {
            var employee = await repo.GetByIdAsync(id);
            return employee is null ? null : ToDto(employee);
        }

        public async Task<EmployeeDto> CreateAsync(CreateEmployeeDto dto)
        {
            if (await repo.EmailExistsAsync(dto.Email))
                throw new AppException($"Email '{dto.Email}' is already registered.", 400);

            var employee = new Employee
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                PolicyId = dto.PolicyId
            };

            var created = await repo.CreateAsync(employee);

            return ToDto(created);
        }
    }
}
