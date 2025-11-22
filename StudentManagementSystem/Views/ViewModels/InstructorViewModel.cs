using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Views.ViewModels
{
    public class InstructorViewModel
    {
        public int Id { get; set; }

        [Required, StringLength(100, ErrorMessage = "100 Characters Maximum")]
        [Display(Name = "Instructor Name", Prompt = "ex : Ali Mohamed Ahmed")]
        public string InstructorName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Hire Date")]
        public DateTime InstructorHireDate { get; set; }

        [StringLength(100, ErrorMessage = "100 Characters Maximum")]
        [Display(Name = "Office Location (Optional)", Prompt = "ex : 123 Main Street, Anytown, USA.")]
        public string? OfficeLocation { get; set; }
    }
}
