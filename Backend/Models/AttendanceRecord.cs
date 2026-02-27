using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class AttendanceRecord
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public DateTime AttendanceDate { get; set; }

        public string Status { get; set; }

        [Range(0,24)]
        public double HoursWorked { get; set; }
        
    }
}
