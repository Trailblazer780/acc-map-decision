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


                //-- Semester-Courses --//
                 foreach (var semester in userResponse.programCourseMap.semesterList ) {
                    csvWriter.WriteField(semester.semesterTitle );
                    csvWriter.NextRecord();

                    foreach (var course in semester.coursesSelected ) {
                        csvWriter.WriteField(course.courseName );
                        csvWriter.NextRecord();
                    }
                 csvWriter.NextRecord();
                 }                    
                //-- Contact Information --//
                csvWriter.WriteField("\n");
                csvWriter.NextRecord();

                File.WriteAllText(csvPath, sb.ToString(), Encoding.Default);    
                Console.WriteLine(csvPath);        
                Console.WriteLine("File Name: "+FileName);    

                  csvWriter.Flush();
            } Console.WriteLine("CSV File Created");
        } // end of CSV-UserResponse
        public async void WriteCSV() {
        }
        }
    }