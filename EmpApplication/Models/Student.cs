using System.ComponentModel.DataAnnotations;

namespace EmpApplication.Models
{
    public class Student
    {
        public int id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string City { get; set; }
    }
}
