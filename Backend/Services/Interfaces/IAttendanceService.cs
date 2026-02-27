using Backend.DTOs;
using Backend.Models;

namespace Backend.Services.Interfaces
{
    public interface IAttendanceService
    {
        //Task<IEnumerable<DailyReportDto>> GetDailyReportAsync(DateTime date);
        Task<AttendanceRecord> CreateAsync(CreateAttendanceDto dto);
        //Task<bool> ExistsAsync(int empId, DateTime date);
    }
}
