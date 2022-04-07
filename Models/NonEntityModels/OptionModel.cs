using System.Collections.Generic;

namespace accmapdecision.Models {
    public class OptionModel {

        public OptionModel(int optionID, string optionText, int nextQuestionId) {
            this.optionID = optionID;
            this.optionText = optionText;
            this.nextQuestionId = nextQuestionId;
            this.courses = new List<CourseModel>();
        }

        public int optionID {get;set;}
        public string optionText {get;set;}

        public int nextQuestionId {get;set;}

        // Courses to add to the list
        public List<CourseModel> courses {get; set;}

        public override string ToString() {
            return "Option: " + optionID + " Text: " + optionText + " NextQuestion: " + nextQuestionId + " CourseCount: " + courses.Count;
        }
    }
}