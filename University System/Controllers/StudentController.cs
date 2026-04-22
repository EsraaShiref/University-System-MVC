using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using University_System.Context;
using University_System.Models;

namespace University_System.Controllers
{
    public class StudentController : Controller
    {
        UniContext db = new UniContext();
        public IActionResult Index()
        {
            var allStds = db.Students.ToList();
            return View("Index",allStds);
        }


        public IActionResult Details(int id)
        {

            var student = db.Students.FirstOrDefault(s => s.Id == id);
            return View("Details", student);

        }
    }
}
