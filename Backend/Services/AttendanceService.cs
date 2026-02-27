using Backend.DTOs;
using Backend.Middlewares;
using Backend.Models;
using Backend.Repositories.Interfaces;
using Backend.Services.Interfaces;

namespace Backend.Services
{
    public class AttendanceService(IAttendanceRepository attendanceRepo,IEmployeeRepository employeeRepo) : IAttendanceService

    {
        public async Task<AttendanceRecord> CreateAsync(CreateAttendanceDto dto)
        {
            if (await attendanceRepo.ExistsAsync(dto.EmployeeId,dto.AttendanceDate))
                throw new AppException("Attendance already exists", 409);

            var emp = await employeeRepo.GetByIdAsync(dto.EmployeeId);

            if (dto.Status == "Absent")
                dto.HoursWorked = 0;

            string finalStatus = dto.Status;
            if(dto.Status =="Present" && dto.HoursWorked < emp.Policy.MinDailyHours)
            {
                finalStatus = "ShortHours";
            
            }

            var rec = new AttendanceRecord
            {
                EmployeeId = dto.EmployeeId,
                AttendanceDate = dto.AttendanceDate,
                Status = finalStatus,
                HoursWorked = dto.HoursWorked
            };
            return await attendanceRepo.CreateAsync(rec);

        }
     
    }
        
}
