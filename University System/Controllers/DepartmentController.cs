using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using University_System.Context;
using University_System.Models;

namespace University_System.Controllers
{
    public class DepartmentController : Controller
    {
        UniContext db = new UniContext();
        public IActionResult Index()
        {
            var departments =db.Departments
                .Include(d => d.Students)
                .Include(d => d.Instructors)
                .ToList();
            return View(departments);
        }
        public IActionResult GetByName(string name)
        {
            var dept = db.Departments
                .Include(d => d.Students)
                .Include(d => d.Instructors)
                .FirstOrDefault(d => d.Name == name);

            if (dept == null) return NotFound();
            return View(dept);
        }

        //get
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Department department)
        {
            db.Departments.Add(department);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var dept = db.Departments.Find(id);
            if (dept == null) return NotFound();
            return View(dept);
        }

        [HttpPost]
        public IActionResult Edit(Department department)
        {
            db.Departments.Update(department);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var dept = db.Departments.Find(id);
            if (dept == null) return NotFound();
            db.Departments.Remove(dept);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
