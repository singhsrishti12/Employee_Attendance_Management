using Backend.DTOs;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController(IReportService service) : ControllerBase
    {
        [HttpGet("daily-attendance")]
        public async Task<IActionResult> GetDailyAttendance( DateTime date)
        {
            var res = await service.GetDailyReportAsync(date);
            return Ok(res);
        }

    }
}
