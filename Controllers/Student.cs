using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Models;
using SchoolProject.Models.Entities;

namespace SchoolProject.Controllers
{
    public class StudentController : Controller
    {
      private readonly DataBaseContext _context;
        public StudentController(DataBaseContext context)
        {
            _context = context;
        }
        //Get: Create
        public async Task<IActionResult> Create()
        {    

           return View();
        }

        //Post: Create
        [HttpPost]
        public async Task<ActionResult> Create(Student Student)
        {
            _context.Students.Add(Student);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        //Get: Details

        
        public async Task<IActionResult> Details(int id)
        {
            var student = _context.Students
                .FirstOrDefault(s => s.Id == id);
            return View(student);
        }

        //Get: Delete
        public async Task<IActionResult> Delete(int id)
        {
            return View(await _context.Students.ToListAsync());
        }
        //post: Delete
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Students.FindAsync(id);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        //Get: Edit
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _context.Students.FindAsync(id));
        }
        //Post: Edit
        [HttpPost]
        public async Task<IActionResult> Edit(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Index()
        {
            var students = await _context.Students.ToListAsync();
            return View(students);
            
        }
        //Get: Enroll
        public async Task<IActionResult> Enroll(int id)
        {
            ViewBag.StudentId = id;
            ViewBag.Courses = await _context.Courses.ToListAsync();
            return View();
        }
        //Post: Enroll
        [HttpPost]
        public async Task<IActionResult> Enroll(int studentId, int courseId)
        {
            var enrollment = new Enrollment
            {
                StudentId = studentId,
                CourseId = courseId,
                EnrolledOn = DateTime.Now
            };
            _context.Enrollments.Add(enrollment);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
