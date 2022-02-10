using System;
using System.Collections.Generic;
using CsvHelper.Configuration;



public class CourseInfoClassMap : ClassMap<CourseInfo>{
       public CourseInfoClassMap()
         {
        Map(r => r.course_code).Name("course_code");
        Map(r => r.course_name).Name("course_name");
        Map(r => r.course_units).Name("course_units");
        Map(r => r.course_description).Name("course_description");
        Map(r => r.course_rationale).Name("course_rationale");
    }
}
 

    public class CourseInfo {

        public string course_code { get; set; }
        public string course_name { get; set; }
        public string course_units { get; set; }
        public string course_description { get; set; }
        public string course_rationale { get; set; }



        public static List<CourseInfo> GetCourses(){
            return new List<CourseInfo>{
                new CourseInfo{
                    course_code = "OSYS1000",
                    course_name = "Operating Systems",
                    course_units = "4",
                    course_description = "nice course",
                    course_rationale = "Web Development"
                }
            };

        }


    }