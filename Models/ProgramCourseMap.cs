using System.Collections.Generic;

namespace accmapdecision.Models {
    public class ProgramCourseMap {
        public List<SemesterCourseMap> semesterList {get;set;} = new List<SemesterCourseMap>();    // Semester-wise courses for the entire program

    }  
}