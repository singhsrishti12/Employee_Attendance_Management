using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
       
        public string Email { get; set; }

        public bool IsActive { get; set; } 

        public  int PolicyId { get; set; }


    }
}
