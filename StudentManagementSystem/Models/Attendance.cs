using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models
{
    public class Attendance
    {
        public int Id { get; set; }

        [Required]
        public int StudentId { get; set; }

        [Required]
        public int CourseId { get; set; }

        [DataType(DataType.Date),Required]
        public DateTime Date { get; set; }

        [Required]
        public bool IsPresent { get; set; }

        //Navigation Properties
        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}
//Attendance (Id, StudentId, CourseId, Date, IsPresent)