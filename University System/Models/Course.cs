namespace University_System.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Topics { get; set; }  
        public int TotalDegree { get; set; }
        public int MinDegree { get; set; }  

        // M:N with Student
        public ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();

        // M:N with Instructor
        public ICollection<CourseInstructor> CourseInstructors { get; set; } = new List<CourseInstructor>();
    }
}