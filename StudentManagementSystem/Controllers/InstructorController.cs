using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;
using StudentManagementSystem.Views.ViewModels;

namespace StudentManagementSystem.Controllers
{
    public class InstructorController : Controller
    {
        UniversityContext _context;

        public InstructorController(UniversityContext context)
        {
            _context = context;
        }

        //####################################### Home ######################################
        public IActionResult Index()
        {
            var Instructors = _context.Instructors.Include(i => i.OfficeAssignment).ToList();
            return View(Instructors);
        }
        //###################################################################################


        //####################################### Instructor Add ############################
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        public async Task<IActionResult> Create(InstructorViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);


            var instructor = new Instructor()
            {
                Name = viewModel.InstructorName,
                HireDate = viewModel.InstructorHireDate
            };


            await _context.Instructors.AddAsync(instructor);
            await _context.SaveChangesAsync();


            if (viewModel.OfficeLocation != null)
            {
                OfficeAssignment office = new OfficeAssignment
                {
                    InstructorId = instructor.Id,
                    Location = viewModel.OfficeLocation
                };

                await _context.OfficeAssignments.AddAsync(office);
                await _context.SaveChangesAsync();
            }


            return RedirectToAction(nameof(Index));
                   
        }
        //###############################################################################



        //############################ Delete ###########################################
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> InstructorDelete(int id)
        {
            var instructor = await _context.Instructors.FindAsync(id);
            _context.Instructors.Remove(instructor);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        //###############################################################################


        //########################### Modify ############################################
        public async Task<IActionResult> Modify(int id)
        {
            var instructor = await _context.Instructors.Include(i => i.OfficeAssignment).FirstAsync(i => i.Id == id);

            var viewModel = new InstructorViewModel()
            {
                Id = instructor.Id,
                InstructorName = instructor.Name,
                InstructorHireDate = instructor.HireDate,
                OfficeLocation = instructor.OfficeAssignment?.Location
            };


            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Modify(InstructorViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);



            var instructor = await _context.Instructors.Include(i => i.OfficeAssignment).FirstAsync(i => i.Id == viewModel.Id);
            instructor.Name = viewModel.InstructorName;
            instructor.HireDate = viewModel.InstructorHireDate;



            if (!viewModel.OfficeLocation.IsNullOrEmpty())
            {
                if (instructor.OfficeAssignment == null)
                {
                    OfficeAssignment officeAssignment = new()
                    {
                        Location = viewModel.OfficeLocation,
                        InstructorId = viewModel.Id
                    };


                    await _context.OfficeAssignments.AddAsync(officeAssignment);
                    await _context.SaveChangesAsync();
                }
                else
                    instructor.OfficeAssignment.Location = viewModel.OfficeLocation;
            }

            _context.Instructors.Update(instructor);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        //###############################################################################





    }
}
