using System.Collections.Generic;

namespace accmapdecision.Models {

    public class SemesterCourseMap {
        public int semesterId {get;set;}

        public string semesterTitle {get;set;}      // Can be Fall 2020, Winter 2021
        public List<CourseModel> coursesSelected {get;set;} = new List<CourseModel>();  // List of all courses selected for this semester

        // Add eligible courses - Checking pre requisites
        public List<CourseModel> eligibleCourses {get;set;} = new List<CourseModel>();  // List of all courses selected for this semester
    }  
}