using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace accmapdecision.Models {

    [Table("tblSemester")]
    public class SemesterCourseMap {
        public string semesterTitle {get;set;}      // Can be Fall 2020, Winter 2021
        public List<string> coursesSelected {get;set;} = new List<string>();  // List of all course names selected for this semester
    }  
}