using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace accmapdecision.Models {

    public class Semester {
        [Key]
        public int semester_id {get; set;}
        [Required]
        [Display(Name="Semester Code")]
        public string semester_code {get; set;} 

        // private DbSet<CourseOffered> tblCourse_semester {get; set;}

        // public List<CourseOffered> course_semester {
        //     get {
        //         // return tblCourse_semester.OrderBy(i => i.course_id).Where().ToList();
        //         // return the courses offered in the semester
        //         return tblCourse_semester.OrderBy(i => i.course_id).Where(i => i.semester_id == semester_id.ToString()).ToList();
        //     }
        // }

    }   
}