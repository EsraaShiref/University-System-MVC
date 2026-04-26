using System.ComponentModel.DataAnnotations.Schema;

namespace University_System.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string SSN { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public string? Image { get; set; }  // path stored in DB


        [NotMapped]  // مش بتتحفظ في الـ DB
        public IFormFile? ImageFile { get; set; }  // الصورة اللي بتجي من الـ Form
        // FK → Department (M:1)
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }

        // M:N → Course
        public ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
    }
}