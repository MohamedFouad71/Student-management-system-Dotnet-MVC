using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models
{
    public class Instructor
    {
        public int Id { get; set; }

        [Required,StringLength(100, ErrorMessage = "100 Characters Maximum")]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }

        //Navigation Properties
        public OfficeAssignment OfficeAssignment { get; set; }
    }
}
