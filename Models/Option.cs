using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
namespace accmapdecision.Models {

    [Table("tblOption")]
    public class Option {

        public Option(int optionID, string optionText, int nextQuestionId) {
            this.optionID = optionID;
            this.optionText = optionText;
            this.nextQuestionId = nextQuestionId;
        }
        public Option(string optionText) {
            this.optionText = optionText;
        }

        public int optionID {get;set;}
        public string optionText {get;set;}

        public int questionId {get;set;}

        public Question question {get;set;}

        public int nextQuestionId {get;set;}

        public Question nextQuestion {get;set;}

        // Courses to add to the list
        public ICollection<Course> courses {get; set;}

        public List<OptionCourseMapping> optionCourseMapping {get; set;}

        public override string ToString() {
            return "Option: " + optionID + " Text: " + optionText + " NextQuestion: " + nextQuestionId;
        }
    }  
}