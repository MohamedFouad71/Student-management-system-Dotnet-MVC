using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Controllers
{
    public class AttendanceController : Controller
    {
        UniversityContext _context;

        public AttendanceController(UniversityContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var attendance = _context.Attendances.Include(a => a.Course).Include(a => a.Student).ToList();
            return View(attendance);
        }


        //################################ Student Attendence #############################
        [HttpGet("StudentAttendence")]
        public async Task<IActionResult> StudentAttendance(int id)
        {
            var student = await _context.Students
                .Include(s => s.Attendances)
                .ThenInclude(a => a.Course)
                .FirstOrDefaultAsync(s => s.Id == id);

            return View(student);
        }
        // ###############################################################################



        // ################################ Course Attendence ############################
        public async Task<IActionResult> CourseAttendance(int id)
        {
            var course = await _context.Courses
                .Include(c => c.Attendances)
                .ThenInclude(a => a.Student)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (course == null || course.Attendances == null)
                return NotFound("No Records Found");

            return View(course);
        }
        //################################################################################



        // ################################# Add #########################################
        [HttpGet]
        public IActionResult Add(int studentId)
        {
            var courses = _context.Courses.ToList();

            var viewModel = new AttendanceViewModel
            {
                StudentId = studentId,
                Courses = courses.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList()
            };

            return View(viewModel);
        }

        // POST: Attendance/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AttendanceViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Courses = _context.Courses.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();
                return View(viewModel);
            }

            var attendance = new Attendance
            {
                StudentId = viewModel.StudentId,
                CourseId = viewModel.CourseId,
                Date = viewModel.Date,
                IsPresent = viewModel.IsPresent
            };

            _context.Attendances.Add(attendance);
            await _context.SaveChangesAsync();

            return RedirectToAction("StudentAttendance", new { id = viewModel.StudentId });
        }
        //###########################################################################



        //####################################
    }
}
