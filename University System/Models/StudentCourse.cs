using System.ComponentModel.DataAnnotations.Schema;

namespace University_System.Models
{
    public class StudentCourse
    {
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public Student Student { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public double Grade { get; set; }  
    }
}