using System.Collections.Generic;

namespace accmapdecision.Models {
    public class UserResponse {
        public List<Question> questionsAndResponses {get;set;} = new List<Question>();   // All questions and the related details
        public ProgramCourseMap programCourseMap {get;set;} = new ProgramCourseMap();   // Courses selected for the entire program
    }  
}