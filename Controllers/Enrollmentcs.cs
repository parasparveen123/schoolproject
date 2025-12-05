using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Models;
using SchoolProject.Models.Entities;

namespace SchoolProject.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly DataBaseContext _context;
        public EnrollmentController(DataBaseContext context)
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
        public async Task<ActionResult> Create(Enrollment enrollment)
        {
            _context.Enrollments.Add(enrollment);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        //Get: Details

        [HttpPost]
        public async Task<IActionResult> Details(int id)
        {
            var enrollment = _context.Enrollments
                .FirstOrDefault(s => s.Id == id);
            return View(enrollment);
        }

        //Get: Delete
        public async Task<IActionResult> Delete(int id)
        {
            return View(await _context.Enrollments.ToListAsync());
        }
        //post: Delete
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enrollment = await _context.Enrollments.FindAsync(id);
            _context.Enrollments.Remove(enrollment);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        //Get: Edit
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _context.Enrollments.FindAsync(id));
        }
        //Post: Edit
        [HttpPost]
        public async Task<IActionResult> Edit(Enrollment enrollment)
        {
            _context.Enrollments.Update(enrollment);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Index()
        {
            var enrollments = await _context.Enrollments.ToListAsync();
            return View(enrollments);

        }
    }
}
