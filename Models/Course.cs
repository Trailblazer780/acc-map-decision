using System;
using System.ComponentModel.DataAnnotations;

namespace accmapdecision.Models {
    // category class to use in the database
    public class Course {
        [Key]
        public int id {get; set;}
        [Required]
        [Display(Name="Course Code")]
        public string course_code {get; set;}
        [Required]
        [Display(Name="Course Name")]
        public string course_name {get; set;}
        [Required]
        [Display(Name="Course Description")]
        public string course_description {get; set;}
        [Required]
        [Display(Name="Course Rationale")]
        public string course_rationale {get; set;}
    }
}