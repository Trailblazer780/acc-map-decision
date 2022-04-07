using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace accmapdecision.Models {
    
    [Table("tblOptionCourse")]
    public class OptionCourseMapping {

        public int optionId {get; set;}
        
        public int courseId {get; set;}

        public Option option {get; set;}
        
        public Course course {get; set;}
    }
}