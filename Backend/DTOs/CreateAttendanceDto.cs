using Backend.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.DTOs
{
    public class CreateAttendanceDto
    {
        [Required]
        public int EmployeeId { get; set; }
        public DateTime AttendanceDate { get; set; }
        public string Status { get; set; }

        [Range(0, 24)]
        public double HoursWorked { get; set; }
    }
}
