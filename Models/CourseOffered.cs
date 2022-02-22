using System;
using System.ComponentModel.DataAnnotations;

namespace accmapdecision.Models {
    // category class to use in the database
    public class CourseOffered {
        [Key]
        [Required]
        [Display(Name = "Course ID")]
        public int course_id {get; set;}
        [Required]
        [Display(Name="Semester")]
        public string semester_id {get; set;}
    }
}