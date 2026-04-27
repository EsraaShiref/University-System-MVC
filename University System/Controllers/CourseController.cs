using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using University_System.Context;
using University_System.Models;
using University_System.ViewModels;
using System.Linq;
using System.Collections.Generic;

namespace University_System.Controllers
{
    public class CourseController : Controller
    {
        UniContext db = new UniContext();

        // عرض جميع الكورسات مع أسماء الطلاب والمحاضرين
        public IActionResult Index()
        {
            var courses = db.Courses
                .Include(c => c.StudentCourses)
                .ThenInclude(sc => sc.Student)
                .Include(c => c.CourseInstructors)
                .ThenInclude(ci => ci.Instructor)
                .ToList()
                .Select(c => new CourseViewModel
                {
                    CourseId = c.CourseId,
                    Name = c.Name,
                    Description = c.Description,
                    Topics = c.Topics,
                    TotalDegree = c.TotalDegree,
                    MinDegree = c.MinDegree,
                    Students = c.StudentCourses
                        .Select(sc => new StudentInCourseViewModel
                        {
                            StudentId = sc.Student.Id,
                            StudentName = sc.Student.Name,
                            Grade = (int)sc.Grade
                        })
                        .ToList(),
                    Instructors = c.CourseInstructors
                        .Select(ci => new InstructorInCourseViewModel
                        {
                            InstructorId = ci.Instructor.InstructorId,
                            InstructorName = ci.Instructor.Name,
                            Hours = ci.Hours
                        })
                        .ToList()
                })
                .ToList();

            return View(courses);
        }

        // البحث عن كورس باسمه وعرض تفاصيله مع أسماء الطلاب والمحاضرين
        public IActionResult GetByName(string name)
        {
            var course = db.Courses
                .Include(c => c.StudentCourses)
                .ThenInclude(sc => sc.Student)
                .Include(c => c.CourseInstructors)
                .ThenInclude(ci => ci.Instructor)
                .FirstOrDefault(c => c.Name == name);

            if (course == null)
                return NotFound();

            var courseViewModel = new CourseViewModel
            {
                CourseId = course.CourseId,
                Name = course.Name,
                Description = course.Description,
                Topics = course.Topics,
                TotalDegree = course.TotalDegree,
                MinDegree = course.MinDegree,
                Students = course.StudentCourses
                    .Select(sc => new StudentInCourseViewModel
                    {
                        StudentId = sc.Student.Id,
                        StudentName = sc.Student.Name,
                        Grade = (int)sc.Grade
                    })
                    .ToList(),
                Instructors = course.CourseInstructors
                    .Select(ci => new InstructorInCourseViewModel
                    {
                        InstructorId = ci.Instructor.InstructorId,
                        InstructorName = ci.Instructor.Name,
                        Hours = ci.Hours
                    })
                    .ToList()
            };

            return View(courseViewModel);
        }

        // GET - إضافة كورس جديد
        public IActionResult Add()
        {
            return View();
        }

        // POST - إضافة كورس جديد
        [HttpPost]
        public IActionResult Add(Course course)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(course);
        }

        // GET - تعديل كورس
        public IActionResult Edit(int id)
        {
            var course = db.Courses.Find(id);
            if (course == null)
                return NotFound();
            return View(course);
        }

        // POST - تعديل كورس
        [HttpPost]
        public IActionResult Edit(Course course)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Update(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(course);
        }

        // حذف كورس
        public IActionResult Delete(int id)
        {
            var course = db.Courses.Find(id);
            if (course == null)
                return NotFound();
            db.Courses.Remove(course);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}