using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace accmapdecision.Models {
    
    [Table("tblCourse_semester")]
    public class CourseOffered {
        [Key]
        [Required]
        [Display(Name = "Course ID")]
        public int course_id {get; set;}
        [Required]
        [Display(Name="Semester")]
        public int semester_id {get; set;}

        public Course course {get; set;}
        public Semester semester {get; set;}
    }
}