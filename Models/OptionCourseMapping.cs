using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace accmapdecision.Models {
    
    [Table("tblOptionCourse")]
    public class OptionCourseMapping {

        [Key]
        [Required]
        public int option_id {get; set;}
        
        [Key]
        [Required]
        public int id {get; set;}

        public Option option {get; set;}
        public Course course {get; set;}
    }
}