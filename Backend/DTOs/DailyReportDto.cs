namespace Backend.DTOs
{
    public class DailyReportDto
    {
        public int EmployeeId { get; set; }

        public string FullName { get; set; }

        public string PolicyName { get; set; }

        public double MinDailyHours { get; set; }

        public DateTime AttendanceDate { get; set; }

        public string Status { get; set; }

        public double HoursWorked { get; set; }

        public string DailyFlag { get; set; }

    }
}
