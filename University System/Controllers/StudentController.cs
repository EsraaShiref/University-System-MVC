using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using University_System.Context;

namespace University_System.Controllers
{
    public class StudentController : Controller
    {
        UniContext db = new UniContext();
        public IActionResult Index()
        {
            var students = db.Students
    .Include(s => s.Department)
    .Include(s => s.StudentCourses)
    .ToList();
            return View("Index", students);
        }


        public IActionResult Details(int id)
        {

            var student = db.Students
                                 .Include(s => s.Department)
                                 .Include(s => s.StudentCourses)
                                     .ThenInclude(sc => sc.Course)
                                 .FirstOrDefault(s => s.Id == id);
            return View("Details", student);

        }
    }
}
