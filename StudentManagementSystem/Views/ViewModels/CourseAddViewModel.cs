using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Views.ViewModels
{
    public class CourseAddViewModel
    {
        [Required, StringLength(50, ErrorMessage = "50 Characters Maximum")]
        [Display(Name = "Course Name", Prompt = "ex : Data Structures")]
        public string Name { get; set; }

        public short Credits { get; set; }

        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        public List<SelectListItem>? Departments { get; set; }

        public readonly List<SelectListItem> CreditsList = new()
        {
            new() {Text = "0", Value = "0"},
            new() {Text = "1", Value = "1"},
            new() {Text = "2", Value = "2"},
            new() {Text = "3", Value = "3"},
            new() {Text = "4", Value = "4"},
            new() {Text = "5", Value = "5"},
            new() {Text = "6", Value = "6"},
        };

    }
}
