namespace University_System.Models
{
    public class Instructor
    {
        public int InstructorId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public string Degree { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        // FK
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        // M:N with Course
        public ICollection<CourseInstructor> CourseInstructors { get; set; } = new List<CourseInstructor>();
    }
}