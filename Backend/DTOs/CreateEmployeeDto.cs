using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs
{
    public class CreateEmployeeDto
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required ,EmailAddress]
        public string Email { get; set; }

        public int PolicyId { get; set; }
    }
}
