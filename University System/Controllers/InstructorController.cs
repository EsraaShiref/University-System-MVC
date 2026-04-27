using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using University_System.Context;
using University_System.Models;

namespace University_System.Controllers
{
    public class InstructorController : Controller
    {
        UniContext db = new UniContext();

        public IActionResult Index()
        {
            var instructors = db.Instructors
                .Include(i => i.Department)
                .Include(i => i.CourseInstructors)
                .ToList();
            return View("Index", instructors);
        }

        public IActionResult Details(int id)
        {
            var instructor = db.Instructors
                .Include(i => i.Department)
                .Include(i => i.CourseInstructors)
                    .ThenInclude(ci => ci.Course)
                .FirstOrDefault(i => i.InstructorId == id);

            if (instructor == null) return NotFound();
            return View("Details", instructor);
        }

        // GET
        public IActionResult Add()
        {
            ViewBag.Departments = db.Departments.ToList();
            return View("AddInstructor");
        }

        // POST
        [HttpPost]
        public IActionResult Add(Instructor instructor)
        {
            db.Instructors.Add(instructor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var instructor = db.Instructors.Find(id);
            if (instructor == null)
            {
                return NotFound();
            }
            ViewBag.Departments = db.Departments.ToList();
            return View(instructor);
        }

        [HttpPost]
        public IActionResult Edit(Instructor instructor)
        {
            var existing = db.Instructors.Find(instructor.InstructorId);
            if (existing == null) return NotFound();

            existing.Name = instructor.Name;
            existing.Age = instructor.Age;
            existing.Salary = instructor.Salary;
            existing.Degree = instructor.Degree;
            existing.Email = instructor.Email;
            existing.Address = instructor.Address;
            existing.DepartmentId = instructor.DepartmentId;

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var instructor = db.Instructors.Find(id);
            if (instructor == null) return NotFound();
            db.Instructors.Remove(instructor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}