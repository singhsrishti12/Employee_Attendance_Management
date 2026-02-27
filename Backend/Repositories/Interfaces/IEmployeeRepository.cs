using Backend.Models;

namespace Backend.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee?> GetByIdAsync(int id);
        Task<Employee> CreateAsync(Employee st);
        Task<bool> EmailExistsAsync(string email, int excludeId = 0);
    }
}
