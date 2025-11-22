using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementSystem.Models
{
    public class OfficeAssignment
    {
        [Key,ForeignKey(nameof(Instructor))]
        public int InstructorId { get; set; }

        [Required,StringLength(100, ErrorMessage = "100 Characters Maximum")]
        public string Location { get; set; }

        //Navigation Properties
        public Instructor Instructor { get; set; }
    }
}
//OfficeAssignment (InstructorId, Location)