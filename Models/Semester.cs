using System;
using System.ComponentModel.DataAnnotations;
namespace accmapdecision.Models {

    public class Semester {
        [Key]
        public int semester_id {get; set;}
        [Required]
        [Display(Name="Semester Code")]
        public string semester_code {get; set;} 
    }   
}