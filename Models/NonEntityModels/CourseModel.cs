using System.Collections.Generic;
namespace accmapdecision.Models {

    public class CourseModel {

        public CourseModel(int courseID, string courseCode, string courseName, float courseUnits) {
            this.courseID = courseID;
            this.courseCode = courseCode;
            this.courseName = courseName;
            this.courseUnits = courseUnits;
            this.preRequisites = new List<CourseModel>();
            this.show = true;
        }

        public int courseID {get;set;}
        public string courseCode {get;set;}
        public string courseName {get;set;}
        public float courseUnits {get;set;}
        public bool show {get;set;}
        public List<CourseModel> preRequisites {get; set;}

        public override string ToString() {
            return "Course: " + courseCode + " ID: " + courseID + " Units: " + courseUnits;
        }

        public override bool Equals(object o){
            if(o.GetType() != typeof(CourseModel))
                return false;

            return (this.courseID == ((CourseModel)o).courseID);
        }

        public override int GetHashCode(){
            return courseID.GetHashCode();
        }
    }  
}