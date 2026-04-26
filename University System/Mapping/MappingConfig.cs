using Mapster;
using University_System.Models;
using University_System.ViewModels;

namespace University_System.Mapping
{
    public static class MappingConfig
    {
        public static void RegisterMappings()
        {
            TypeAdapterConfig<Student, StudentDetailsVM>.NewConfig()
                .Map(dest => dest.DepartmentName,
                     src => src.Department != null ? src.Department.Name : "N/A")
                .Map(dest => dest.Courses,
                     src => src.StudentCourses == null
                         ? new List<CourseGradeVM>()
                         : src.StudentCourses
                             .Where(sc => sc.Course != null)
                             .Select(sc => new CourseGradeVM
                             {
                                 CourseName = sc.Course.Name,
                                 Grade = sc.Grade
                             }).ToList());
        }
    }
}
