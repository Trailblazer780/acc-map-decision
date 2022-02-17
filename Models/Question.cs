using System.Collections.Generic;

namespace accmapdecision.Models {
    public class Question {
        public int questionID {get;set;}
        public string questionText {get;set;}       // Question to display
        public List<Option> optionsList {get;set;}     // Options to display
        public Option optionSelected {get;set;}     // Selected option

        public override string ToString() {
            return "Question: " + questionText + " ID: " + questionID;
        }
    }  
}