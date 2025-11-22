using StudentManagementSystem.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace StudentManagementSystem.Models
{
    public class Enrollment
    {
        public int Id { get; set; }

        [Required]
        public int StudentId { get; set; }

        [Required]
        public int CourseId { get; set; }

        [Range(0,100)]
        public int? Grade { get; set; } // ask chat gpt if it is nullable in real life or not

        //Navigation Properties
        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}
//Enrollment(Id, StudentId, CourseId, Grade)
