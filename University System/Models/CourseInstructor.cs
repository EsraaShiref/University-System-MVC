namespace University_System.Models
{
    public class CourseInstructor
    {
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }

        public int Hours { get; set; }  // relationship attribute
    }
}