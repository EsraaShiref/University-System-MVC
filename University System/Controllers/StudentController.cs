using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using University_System.Context;
using University_System.Models;
using University_System.ViewModels;

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

        // GET 
        public IActionResult Add()
        {
            ViewBag.Departments = db.Departments.ToList();
            return View("AddStudent");
        }

        // POST 
        [HttpPost]
        public IActionResult Add(Student student)
        {
            // حفظ الصورة على السيرفر
            if (student.ImageFile != null && student.ImageFile.Length > 0)
            {
                string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");

                // إنشاء الفولدر لو مش موجود
                if (!Directory.Exists(uploadsFolder))
                    Directory.CreateDirectory(uploadsFolder);

                // اسم فريد للصورة عشان متتكررش
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + student.ImageFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                // حفظ الصورة
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    student.ImageFile.CopyTo(stream);
                }

                student.Image = uniqueFileName; // بنحفظ الاسم بس في الـ DB
            }

            db.Students.Add(student);
            db.SaveChanges();

            return RedirectToAction("Index");
        }


        public ActionResult Edit(int id)
        {
            var student = db.Students.Find(id);
            if(student == null)
            {
                return NotFound();
            }
            ViewBag.Departments = db.Departments.ToList();
            return View(student);
        }

        public IActionResult DetailsVm(int id)
        {
            var student = db.Students
                .Include(s => s.Department)
                .Include(s => s.StudentCourses)
                    .ThenInclude(sc => sc.Course)
                .FirstOrDefault(s => s.Id == id);

            if (student == null) return NotFound();

            var vm = student.Adapt<StudentDetailsVM>();
            return View(vm);
        }
    }
}
