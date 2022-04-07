using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using System.Linq;
using System.Text;
<<<<<<< HEAD
=======
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.AspNetCore.Hosting;

>>>>>>> cff145e23abc0dc08d8e5d73b27e068b05406e06

namespace accmapdecision.Models {

    public class CSVModel : DbContext {
    
        public string FileName { get; set; }
        public string csvPath { get; set; }

<<<<<<< HEAD
        public string FileName { get; set; }

        // public CSVModel() {
        // }

        // public void WriteCSV(UserResponse userResponse) {
        public async void WriteCSV(List<Course> courses) {
            var csvPath = Path.Combine(Environment.CurrentDirectory , $"courses-{DateTime.Now.ToFileTime()}.csv");
=======
        //-- CSV-UserResponse --//
        public async void WriteCSV(UserResponse userResponse ) { 
            FileName = $"csv-{DateTime.Now.ToFileTime()}.csv";

            var csvPath = Path.Combine(Environment.CurrentDirectory+ "/wwwroot/Files/" , FileName);
            // var csvPath = Path.Combine(this.Environment.WebRootPath, "Files/", FileName);
    
>>>>>>> cff145e23abc0dc08d8e5d73b27e068b05406e06
            var sb = new StringBuilder();
            using (var streamWriter = new StringWriter(sb))
            using (var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
            {
<<<<<<< HEAD
               
                csvWriter.WriteField("Course Code");
                csvWriter.WriteField("Course Name");
                csvWriter.WriteField("Description");
                // csvWriter.WriteField("CourseRationale");
                csvWriter.NextRecord();
                foreach (var course in courses) {
                    csvWriter.WriteField(course.course_code);
                    csvWriter.WriteField(course.course_name);
                    csvWriter.WriteField(course.course_description);
                    // csvWriter.WriteField(course.course_rationale);
                    csvWriter.NextRecord();
                } 
                File.WriteAllText(csvPath, sb.ToString(), Encoding.Default);            
                Console.WriteLine("File Name: "+"");    
                //   Exports all the courses in allCourses for now
                //   Console.WriteLine(csvPath.ToString());
                //   File.Open(csvPath));

                  csvWriter.Flush();
                

          
            } Console.WriteLine("CSV File Created");
                // BrowserDownload download = new BrowserDownload();
                Console.WriteLine("Current Directory: "+Environment.CurrentDirectory);
                // BrowserDownload.downloadFile("/courses-132912356960695740.csv",Environment.CurrentDirectory );
            Console.WriteLine(Environment.CurrentDirectory+"/"); // Might have to test it and give permmisions
            // Need file name



        } 



=======
                //-- Questions-Response --//
                csvWriter.WriteField("Questions");
                csvWriter.WriteField("Response");                
                csvWriter.NextRecord();

                foreach (var question in userResponse.questionsAndResponses ) {
                    csvWriter.WriteField(question.questionText);
                    csvWriter.WriteField(question.selectedOptionText);
                    csvWriter.NextRecord();
                } csvWriter.NextRecord();

                int longestSemesterCourses = userResponse.programCourseMap.semesterList.Max(w => w.coursesSelected.Count);

                //-- Semester-Courses --//
                foreach (var semester in userResponse.programCourseMap.semesterList ) {
                    csvWriter.WriteField(semester.semesterTitle );
                } csvWriter.NextRecord();
                int i=0;
                for (int n=0; n<longestSemesterCourses; n++) {
                    foreach (var semester in userResponse.programCourseMap.semesterList ) {
                        if( semester.coursesSelected.Count < i+1)  {
                            csvWriter.WriteField("");
                        } else { csvWriter.WriteField(semester.coursesSelected[i].courseName); }
                    } i++;
                csvWriter.NextRecord();
                } csvWriter.NextRecord();

                File.WriteAllText(csvPath, sb.ToString(), Encoding.Default);    
                Console.WriteLine(csvPath);        
                Console.WriteLine("File Name: "+FileName);    
                //   Exports all the courses in allCourses for now
                //   Console.WriteLine(csvPath.ToString());
                //   File.Open(csvPath));
                  csvWriter.Flush();
            } Console.WriteLine("CSV File Created");
            
            // Delete the csv file from project folder

        } // end of CSV-UserResponse

        public async void WriteCSV() {

        }
>>>>>>> cff145e23abc0dc08d8e5d73b27e068b05406e06







<<<<<<< HEAD


=======
>>>>>>> cff145e23abc0dc08d8e5d73b27e068b05406e06
        }
    }

