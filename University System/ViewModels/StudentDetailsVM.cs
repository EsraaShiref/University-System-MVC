namespace University_System.ViewModels
{
    public class StudentDetailsVM
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string? Image { get; set; }
        public string DepartmentName { get; set; }
        public List<CourseGradeVM> Courses { get; set; } = new();
    }

    public class CourseGradeVM
    {
        public string CourseName { get; set; }
        public double Grade { get; set; }
    }
}
