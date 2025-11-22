using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Views.ViewModels
{
    public class StudentViewModel
    {
        public int Id { get; set; }

        [Required, StringLength(100, ErrorMessage = "100 Characters Maximum")]
        [Display(Prompt = "ex : Mohamed Fouad Rashed")]
        public string Name { get; set; }

        [EmailAddress, Required]
        [Display(Prompt = "ex : MohamedFouad12@gmail.com")]
        public string Email { get; set; }

        [DataType(DataType.Date), Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        public List<SelectListItem>? Departments { get; set; }
    }
}
