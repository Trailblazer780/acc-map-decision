using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.AspNetCore.Hosting;
namespace accmapdecision.Models {
    public class CSVModel : DbContext {
        public string FileName { get; set; }
        public string csvPath { get; set; }
        //-- CSV-UserResponse --//
        public async void WriteCSV(UserResponse userResponse ) { 
            FileName = $"csv-{DateTime.Now.ToFileTime()}.csv";
            var csvPath = Path.Combine(Environment.CurrentDirectory+ "/wwwroot/Files/" , FileName);
            // var csvPath = Path.Combine(this.Environment.WebRootPath, "Files/", FileName);
            var sb = new StringBuilder();
            using (var streamWriter = new StringWriter(sb))
            using (var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
            {
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
        }
    }