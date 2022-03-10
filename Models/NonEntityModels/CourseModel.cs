namespace accmapdecision.Models {

    public class CourseModel {

        public CourseModel(int courseID, string courseCode) {
            this.courseID = courseID;
            this.courseCode = courseCode;
        }

        public int courseID {get;set;}
        public string courseCode {get;set;}

        public override string ToString() {
            return "Course: " + courseCode + " ID: " + courseID;
        }
    }  
}