using Backend.DTOs;
using Backend.Models;

namespace Backend.Repositories.Interfaces
{
    public interface IAttendanceRepository
    {
        Task<IEnumerable<DailyReportDto>> GetDailyReportAsync(DateTime date);
        Task<AttendanceRecord> CreateAsync(AttendanceRecord re);
        Task<bool> ExistsAsync(int empId,DateTime date);
    }
}
