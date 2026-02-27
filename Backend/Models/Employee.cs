using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Policy")]
        public int PolicyId { get; set; }

        public Policy Policy { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required,EmailAddress]
        public string Email { get; set; }

        public bool IsActive { get; set; } = true;

        public ICollection<AttendanceRecord> AttendanceRecords { get; set; } = new List<AttendanceRecord>();
    }
}
