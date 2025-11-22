using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

public class AttendanceViewModel
{
    public int StudentId { get; set; }

    [Required]
    public int CourseId { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime Date { get; set; }

    [Required]
    public bool IsPresent { get; set; }


    public List<SelectListItem>? Courses { get; set; }
}
