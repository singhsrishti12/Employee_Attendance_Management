using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Policy
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public double MinDailyHours { get; set; }

        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
