using System.Collections.Generic;

namespace University_System.ViewModels
{
    public class CourseViewModel
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Topics { get; set; }
        public int TotalDegree { get; set; }
        public int MinDegree { get; set; }

        // قائمة بأسماء الطلاب المسجلين في الكورس
        public List<StudentInCourseViewModel> Students { get; set; } = new List<StudentInCourseViewModel>();

        // قائمة بأسماء المحاضرين
        public List<InstructorInCourseViewModel> Instructors { get; set; } = new List<InstructorInCourseViewModel>();
    }

    public class StudentInCourseViewModel
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int Grade { get; set; }
    }

    public class InstructorInCourseViewModel
    {
        public int InstructorId { get; set; }
        public string InstructorName { get; set; }
        public int Hours { get; set; }
    }
}