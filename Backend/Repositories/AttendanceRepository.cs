using Backend.Data;
using Backend.DTOs;
using Backend.Models;
using Backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public class AttendanceRepository(AppDbContext db) : IAttendanceRepository
    {
        public async Task<AttendanceRecord> CreateAsync(AttendanceRecord re)
        {
            db.AttendanceRecords.Add(re);
            await db.SaveChangesAsync();
            return re;
        }
        public async Task<bool> ExistsAsync(int empId, DateTime date)
        {
            return await db.AttendanceRecords.AnyAsync(a => a.EmployeeId == empId && a.AttendanceDate == date);
        }
        public async Task<IEnumerable<DailyReportDto>> GetDailyReportAsync(DateTime date)
        {
            var query = from attendance in db.AttendanceRecords
                        join employee in db.Employees on attendance.EmployeeId equals employee.Id
                        join policy in db.Policies on employee.PolicyId equals policy.Id
                        where attendance.AttendanceDate >= date && attendance.AttendanceDate <= date.AddDays(1)
                        select new DailyReportDto
                        {
                            EmployeeId = employee.Id,
                            FullName = employee.FirstName + " " + employee.LastName,
                            PolicyName = policy.Name,
                            MinDailyHours = policy.MinDailyHours,
                            AttendanceDate = attendance.AttendanceDate,
                            Status = attendance.Status,
                            HoursWorked = attendance.HoursWorked,
                            DailyFlag = attendance.Status == "ShortHours" ? "PolicyViolation" : "OK"
                        };
            return await query.ToListAsync();
        }

    }
}
