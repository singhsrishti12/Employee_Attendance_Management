using Backend.DTOs;

namespace Backend.Services.Interfaces
{
    public interface IReportService
    {
        Task<IEnumerable<DailyReportDto>> GetDailyReportAsync(DateTime date);

    }
}
