using Backend.Data;
using Backend.Models;
using Backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public class EmployeeRepository(AppDbContext db) : IEmployeeRepository
    {
        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await db.Employees
                .Include(e => e.Policy)
                .ToListAsync();
        }
        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await db.Employees
                .Include(e => e.Policy)
                .FirstOrDefaultAsync(s => s.Id == id);
        }
        public async Task<Employee> CreateAsync(Employee st)
        {
            db.Employees.Add(st);
            await db.SaveChangesAsync();
            return st;
        }
        public async Task<bool> EmailExistsAsync(string email, int excludeId = 0)
        {
            return await db.Employees
                   .AnyAsync(s => s.Email.ToLower() == email.ToLower() && s.Id != excludeId);
        }
    }
}
