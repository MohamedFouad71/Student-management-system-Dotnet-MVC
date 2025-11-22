using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models
{
    public class Student
    {
        public int Id { get; set; } // by convention primary key

        [Required,StringLength(100,ErrorMessage = "100 Characters Maximum")] // Reference types needs to be required to be NOT NULL in database
        public string Name { get; set; }

        [EmailAddress,Required]
        public string Email { get; set; }

        [DataType(DataType.Date),Required] // required is Not neccecary, but to keep code cleaner, DataType gives hints to UI
        public DateTime DateOfBirth { get; set; }

        [Required]
        public int DepartmentId { get; set; } // by Convention will be foreign key, even if it was not written

        //Navigation Properties
        public Department Department { get; set; }
        public ICollection<Attendance>? Attendances { get; set; } // Icollection for more initialization flexablity
        public ICollection<Enrollment>? Enrollments { get; set; }
    }
}

/*
 * To Add:
 *   - Display Annotations
 *   
 */