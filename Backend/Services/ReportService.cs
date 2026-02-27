using Backend.DTOs;
using Backend.Repositories.Interfaces;
using Backend.Services.Interfaces;

namespace Backend.Services
{
    public class ReportService(IAttendanceRepository attendanceRepo) : IReportService
    {
        public async Task<IEnumerable<DailyReportDto>> GetDailyReportAsync(DateTime date)
        {
            return await attendanceRepo.GetDailyReportAsync(date);
        }
    }
}
