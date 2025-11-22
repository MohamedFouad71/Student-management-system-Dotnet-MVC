using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required,StringLength(50, ErrorMessage = "50 Characters Maximum")]
        [Display(Name="Course Name",Prompt ="ex : Data Structures")]
        public string Name { get; set; }

        [Range(0,6, ErrorMessage = "Maximum 6 hours"),Required]
        [Display(Name = "Credit Hours", Prompt = "A number from 1 to 6")]
        public short Credits { get; set; }

        public int DepartmentId { get; set; }

        //Navigation Properties
        public ICollection<Attendance>? Attendances { get; set; }
        public ICollection<Enrollment>? Enrollments { get; set; }
        public Department? Department { get; set; }
    }
}
