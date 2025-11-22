using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;
using StudentManagementSystem.Views.ViewModels;

namespace StudentManagementSystem.Controllers
{
    public class CourseController : Controller
    {
        UniversityContext _context;

        public CourseController(UniversityContext context)
        {
            _context = context;
        }

        //######################## Home ###########################
        public IActionResult Index()
        {
            var courses = _context.Courses.Include(c => c.Department).ToList();
            return View(courses);
        }
        //#########################################################



        //####################### Add Course ######################
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            CourseAddViewModel viewModel = new()
            {
                Departments =await _context.Departments.Select(d => new SelectListItem() { Text = d.Name, Value = d.Id.ToString() }).ToListAsync()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CourseAddViewModel viewModel)
        {

            if (!ModelState.IsValid)
            {
                viewModel.Departments = await _context.Departments.Select(d => new SelectListItem() { Text = d.Name, Value = d.Id.ToString() }).ToListAsync();
                return View(viewModel);
            }


            Course course = new()
            {
                Name = viewModel.Name,
                Credits = viewModel.Credits,
                DepartmentId = viewModel.DepartmentId
            };


            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        //#########################################################



        //##################### Course Delete #####################
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CourseDelete(int id)
        {
            if (id == 0)
                return BadRequest("id not found");


            Course course = await _context.Courses.FindAsync(id);


            if (course == null)
                return BadRequest("course not found");


            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        //#########################################################



        //################## Edit ###############################
        public async Task<IActionResult> Modify(int id)
        {
            var course = await _context.Courses.Include(c => c.Department).FirstAsync(c => c.Id == id);

            if (course == null)
                return NotFound();

            ViewBag.Departments = await _context.Departments.ToListAsync();
            ViewBag.Credits = new List<int>() { 0, 1, 2, 3, 4, 5, 6 };

            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Modify(Course course)
        {
            if (!ModelState.IsValid)
                return RedirectToAction(nameof(Modify));

            _context.Courses.Update(course);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        //#######################################################



        //################# Display Attendance ##################

    }
}
