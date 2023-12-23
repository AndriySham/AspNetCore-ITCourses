using System.ComponentModel.DataAnnotations;


namespace Courses
{
    public class Student
    {
        public int Id { get; set; }

        public int GroupId { get; set; }

        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }
    }
}