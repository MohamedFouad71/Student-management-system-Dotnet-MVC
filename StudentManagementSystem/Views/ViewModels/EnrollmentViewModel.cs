using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Views.ViewModels
{
    public class EnrollmentViewModel
    {
        public List<SelectListItem>? Courses { get; set; }

        public int StudentId { get; set; }

        [Display(Name = "Course")]
        public int CourseId { get; set; }

        [Range(0,100,ErrorMessage = "Value for {0} Must be Between {1} and {2}")]
        [Display(Prompt = "0-100")]
        public int? Grade { get; set; }
    }
}
