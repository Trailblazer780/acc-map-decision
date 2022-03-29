using System.Collections.Generic;

namespace accmapdecision.Models {
    public class UserResponse {

        public List<QuestionModel> questionsAndResponses {get;set;} = new List<QuestionModel>();    // All questions and the related details
        
        public List<CourseModel> coursesToInclude {get;set;} = new List<CourseModel>();     // Courses to include based on selected options

        public ProgramCourseMap programCourseMap {get;set;} = new ProgramCourseMap();   // Courses selected for the entire program

        public float totalCourseUnits {get;set;} = 0.0F;

        // Add selectedCourses and remainingCourses
        public List<CourseModel> coursesSelected {get;set;} = new List<CourseModel>();     // Courses Selected by user
        public List<CourseModel> coursesRemaining {get;set;} = new List<CourseModel>();     // Courses remaining to be selected


        public override string ToString() {
            string data = "";
            foreach(QuestionModel question in questionsAndResponses) {
                data += "\nQuestion: " + question.questionText + " selectedOptionText: " + question.selectedOptionText;
            }

            data += "\n----------------------------------------------------\n";

            foreach(CourseModel course in coursesToInclude) {
                data += "\nCourse: " + course.courseCode;
            }

            data += "\n----------------------------------------------------\n";

            data += "\nCourseUnits: " + totalCourseUnits;

            return data;
        }
    }  
}