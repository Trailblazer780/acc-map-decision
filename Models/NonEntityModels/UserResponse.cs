using System.Collections.Generic;

namespace accmapdecision.Models {
    public class UserResponse {

        public List<QuestionModel> questionsAndResponses {get;set;} = new List<QuestionModel>();    // All questions and the related details
        
        public List<CourseModel> coursesToInclude {get;set;} = new List<CourseModel>();     // Courses to include based on selected options

        public ProgramCourseMap programCourseMap {get;set;} = new ProgramCourseMap();   // Courses selected for the entire program

        public override string ToString() {
            string data = "";
            foreach(QuestionModel question in questionsAndResponses) {
                data += "\nQuestion: " + question.questionText + " selectedOptionText: " + question.selectedOptionText;
            }

            data += "\n----------------------------------------------------\n";

            foreach(CourseModel course in coursesToInclude) {
                data += "\nCourse: " + course.courseCode;
            }
            return data;
        }
    }  
}