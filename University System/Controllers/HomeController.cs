using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using University_System.Context;
using University_System.Models;

namespace University_System.Controllers
{
    public class HomeController : Controller
    {
        UniContext db = new UniContext();

        public IActionResult Index()
        {
            ViewBag.StudentCount = db.Students.Count();
            ViewBag.DeptCount = db.Departments.Count();
            ViewBag.CourseCount = db.Courses.Count();
            ViewBag.InstructorCount = db.Instructors.Count();

            var recentStudents = db.Students
                .Include(s => s.Department)
                .Include(s => s.StudentCourses)
                .OrderByDescending(s => s.Id)
                .Take(5)
                .ToList();

            return View(recentStudents);
        }

        public IActionResult Privacy() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() =>
            View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
