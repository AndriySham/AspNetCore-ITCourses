using System.ComponentModel.DataAnnotations;


namespace Courses
{
    public class Group
    {
        public int Id { get; set; }

        public int CourseId { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}