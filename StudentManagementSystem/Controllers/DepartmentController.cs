using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Controllers
{
    public class DepartmentController : Controller
    {
        UniversityContext _context;

        public DepartmentController(UniversityContext context)
        {
            _context = context;
        }


        //##################################### Home Page #########################################
        public IActionResult Index()
        {
            var Departments = _context.Departments.ToList();
            return View(Departments);
        }
        //#########################################################################################


        //#################################### Department Add #####################################
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Department department)
        {
            department.Name = department.Name?.Trim();


            if (_context.Departments.Any(d=> d.Name == department.Name))
            {
                ModelState.AddModelError("Name", "Department Already Exist");
            }


            if (ModelState.IsValid)
            {
                _context.Departments.Add(department);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }


            return View();
        }
        //#########################################################################################


        //############################## Department Remove ########################################

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DepartmentDelete(int id)
        {
            if (id == 0)
            {
                return BadRequest("ID is missing.");
            }
            var department = await _context.Departments.FindAsync(id);

            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        //########################################################################################


        
        //####################################### Modify #########################################
        public async Task<IActionResult> Modify(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            return View(department);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Modify(Department department)
        {
            if (!ModelState.IsValid)
                return View(department);

            _context.Departments.Update(department);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
            //#####################################################################################
        }
    }
}
