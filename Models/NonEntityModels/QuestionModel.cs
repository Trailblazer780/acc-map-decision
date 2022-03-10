using System.Collections.Generic;

namespace accmapdecision.Models {
    
    public class QuestionModel {

        public QuestionModel(int questionID, string questionText, string questionDescription) {
            this.questionID = questionID;
            this.questionText = questionText;
            this.questionDescription = questionDescription;
            this.optionsList = new List<OptionModel>();
        }

        public int questionID {get;set;}
        public string questionText {get;set;}       // Question to display

        public string questionDescription {get;set;}       // Question description to display

        public List<OptionModel> optionsList {get;set;}     // Options to display

        public int selectedOptionId {get;set;}     // Selected option
        public string selectedOptionText {get;set;}     // Selected option

        public override string ToString() {
            return "Question: " + questionText + " ID: " + questionID + " selectedOptionText: " + selectedOptionText;
        }
    }  
}