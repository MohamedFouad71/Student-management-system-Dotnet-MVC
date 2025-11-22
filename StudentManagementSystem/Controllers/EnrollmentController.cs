using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;
using StudentManagementSystem.Views.ViewModels;

namespace StudentManagementSystem.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly UniversityContext _context;

        public EnrollmentController(UniversityContext context)
        {
            _context = context;
        }

        public IActionResult Index(int studentId)
        {
            var enrollments = _context.
                Enrollments.
                Include(e => e.Course).
                Where(e => e.StudentId == studentId).
                ToList();

            ViewBag.studentId = studentId;
            return View(enrollments);
        }

        //#####################################################

        public IActionResult Create(int studentId)
        {
            if (!_context.Students.Any(s => s.Id == studentId))
            {
                return NotFound("Student not found.");
            }

            var courses = _context.
                Courses.
                Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).
                ToList();

            EnrollmentViewModel viewModel = new EnrollmentViewModel { StudentId = studentId, Courses = courses };

            return View(viewModel);
        }


        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EnrollmentViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var courses = await _context.
                    Courses.
                    Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).
                    ToListAsync();

                viewModel.Courses = courses;

                return View(viewModel);
            }

            var enrollment = new Enrollment()
            {
                StudentId = viewModel.StudentId,
                CourseId = viewModel.CourseId,
                Grade = viewModel.Grade
            };

            await _context.Enrollments.AddAsync(enrollment);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index), new {studentId = enrollment.StudentId});
        }
    }
}
