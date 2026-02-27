using Backend.DTOs;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController(IAttendanceService _service) : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAttendanceDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return Ok(created);
        }
    }
}
