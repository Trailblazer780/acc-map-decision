using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace accmapdecision.Models {

    [Table("tblSemester")]
    public class Semester {
        [Key]
        public int semester_id {get; set;}
        [Required]
        [Display(Name="Semester Code")]
        public string semester_code {get; set;} 
        public ICollection<Course> courses {get; set;}
        public List <CourseOffered> courseOffered {get; set;}
    }   
}