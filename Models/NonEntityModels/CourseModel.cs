namespace accmapdecision.Models {

    public class CourseModel {

        public CourseModel(int courseID, string courseCode, float courseUnits) {
            this.courseID = courseID;
            this.courseCode = courseCode;
            this.courseUnits = courseUnits;
        }

        public int courseID {get;set;}
        public string courseCode {get;set;}
        public float courseUnits {get;set;}

        public override string ToString() {
            return "Course: " + courseCode + " ID: " + courseID + " Units: " + courseUnits;
        }
    }  
}