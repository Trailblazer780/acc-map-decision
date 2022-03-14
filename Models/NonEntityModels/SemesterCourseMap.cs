using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace accmapdecision.Models {

    public class SemesterCourseMap {
        public string semesterTitle {get;set;}      // Can be Fall 2020, Winter 2021
        public List<CourseModel> coursesSelected {get;set;} = new List<CourseModel>();  // List of all courses selected for this semester

        // Add eligible courses - Checking pre requisites
    }  
}