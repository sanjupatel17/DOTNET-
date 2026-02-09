using System.ComponentModel.DataAnnotations;

namespace Assignment8_CRUD.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Course { get; set; }

        public int Age { get; set; }
    }
}
