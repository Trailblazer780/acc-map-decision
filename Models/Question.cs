using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace accmapdecision.Models {
    
    [Table("tblQuestion")]
    public class Question {
        public int questionID {get;set;}
        public string questionText {get;set;}       // Question to display

        public string questionDescription {get;set;}       // Question description to display

        public ICollection<Option> optionsList {get;set;}     // Options to display

        [NotMapped]
        public Option optionSelected {get;set;}     // Selected option

        public override string ToString() {
            return "Question: " + questionText + " ID: " + questionID;
        }
    }  
}