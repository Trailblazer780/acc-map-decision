namespace accmapdecision.Models {
    public class UserResponse {
        public int questionID {get;set;}
        public string questionText {get;set;}       // Question to display
        public Option[] optionsArray {get;set;}     // Options to display
        public string optionSelected {get;set;}     // Selected option
        public ProgramCourseMap programCourseMap {get;set;} = new ProgramCourseMap();   // Courses selected for the entire program
    }  
}