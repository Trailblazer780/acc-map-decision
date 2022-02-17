namespace accmapdecision.Models {
    public class Option {

        public Option(int optionID, string optionText, int nextQuestionId) {
            this.optionID = optionID;
            this.optionText = optionText;
            this.nextQuestionId = nextQuestionId;
        }

        public int optionID {get;set;}
        public string optionText {get;set;}
        public int nextQuestionId {get;set;}

        public override string ToString() {
            return "Option: " + optionID + " Text: " + optionText + " NextQuestion: " + nextQuestionId;
        }
    }  
}