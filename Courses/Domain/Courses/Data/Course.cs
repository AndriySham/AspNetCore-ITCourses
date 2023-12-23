using System.ComponentModel.DataAnnotations;


namespace Courses
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [MaxLength(750)]
        public string? Description { get; set; }
    }
}