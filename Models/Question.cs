namespace accmapdecision.Models {
    public class Question {
        public int questionID {get;set;}
        public string questionText {get;set;}       // Question to display
        public Option[] optionsArray {get;set;}     // Options to display
        public string optionSelected {get;set;}     // Selected option
    }  
}