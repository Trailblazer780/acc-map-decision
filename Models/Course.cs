using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace accmapdecision.Models {
    // category class to use in the database
    [Table("tblCourse")]
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
        public ICollection<Semester> semesters {get; set;}
        public List <CourseOffered> courseOffered {get; set;}
    }
}