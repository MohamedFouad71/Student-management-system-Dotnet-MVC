using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;
using StudentManagementSystem.Views.ViewModels;

namespace StudentManagementSystem.Controllers
{
    public class StudentController : Controller
    {
        private readonly UniversityContext _context;

        public StudentController(UniversityContext context)
        {
            _context = context;
        }

        //###################### Index #########################
        public IActionResult Index()
        {
            var Students = _context.Students.Include(s=>s.Department).ToList();
            return View(Students);
        }
        //######################################################



        //################# Create Operation #######################
        [HttpGet]
        public IActionResult Create()
        {
            var departments = _context.Departments.Select(d => new SelectListItem() { Text = d.Name, Value = d.Id.ToString() }).ToList();

            var viewModel = new StudentViewModel() { Departments = departments };

            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken] // Protects from cross site request forgery, involves a two-part token that is unique to the user and the session.
        public async Task<IActionResult> Create(StudentViewModel viewModel)
        {
            Student student;
            if (ModelState.IsValid)
            {
                student = new()
                {
                    DepartmentId = viewModel.DepartmentId,
                    Name = viewModel.Name,
                    Email = viewModel.Email,
                    DateOfBirth = viewModel.DateOfBirth
                };


                _context.Students.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            viewModel.Departments = _context.Departments.Select(d => new SelectListItem() { Text = d.Name, Value = d.Id.ToString() }).ToList();
            return View(viewModel);
        }
        //##########################################################


        //##################### Delete Student #####################

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> StudentDelete(int id)
        {
            if (id == 0) return BadRequest("id not found");


            var student = await _context.Students.FindAsync(id);
            if (student == null) return BadRequest("Student Not Found");


            _context.Students.Remove(student);
            await _context.SaveChangesAsync();


            return RedirectToAction(nameof(Index));

        }
        //##########################################################



        //##########################################################
        public async Task<IActionResult> Modify(int id)
        {
            var student = await _context.Students.FindAsync(id);
            var departments = await _context.Departments.Select(d => new SelectListItem() { Text = d.Name, Value = d.Id.ToString() }).ToListAsync();

            var viewModel = new StudentViewModel()
            {
                Id = student.Id,
                Name = student.Name,
                DateOfBirth = student.DateOfBirth,
                Email = student.Email,
                DepartmentId = student.DepartmentId,
                Departments = departments
            };


            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Modify(StudentViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);


            var student = await _context.Students.FindAsync(viewModel.Id);


            student.Name = viewModel.Name;
            student.DateOfBirth = viewModel.DateOfBirth;
            student.Email = viewModel.Email;
            student.DepartmentId = viewModel.DepartmentId;


            await _context.SaveChangesAsync();


            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult ViewEnrollments()
        {
            return View();
        }


    }
}
