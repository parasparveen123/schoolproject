using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Models;
using SchoolProject.Models.Entities;
using System.Threading.Tasks;
using System.Linq;

namespace SchoolProject.Controllers
{
    public class CourseController : Controller
    {
        private readonly DataBaseContext _context;

        public CourseController(DataBaseContext context)
        {
            _context = context;
        }
        //Get: Create
        public IActionResult Create()
        {
            return View();
        }
        //Post: Create          
        [HttpPost]
        public async Task<ActionResult> Create(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        //Get: Edit
        public async Task<IActionResult> Edit(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null) return NotFound();
            return View(course);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Course course)
        {
            _context.Courses.Update(course);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        //Get: Delete (show single course)
        public async Task<IActionResult> Delete(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null) return NotFound();
            return View(course);
        }
        //post: DeleteConfirmed
        [HttpPost, ActionName("DeleteConfirmed")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        //Get: Details
        public async Task<IActionResult> Details(int id)
        {
            var course = await _context.Courses
                .Include(c => c.Enrollment)
                .ThenInclude(e => e.Student)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (course == null) return NotFound();
            return View(course);
        }

        //Get: Course/Index
        public async Task<IActionResult> Index()
        {
            var course = await _context.Courses.ToListAsync();
            return View(course);
        }
    }
}
