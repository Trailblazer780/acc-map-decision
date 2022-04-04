using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using System.Linq;
using System.Text;

namespace accmapdecision.Models {

    public class CSVModel : DbContext {

        public string FileName { get; set; }

        // public CSVModel() {
        // }

        // public void WriteCSV(UserResponse userResponse) {
        public async void WriteCSV(List<Course> courses) {
            var csvPath = Path.Combine(Environment.CurrentDirectory , $"courses-{DateTime.Now.ToFileTime()}.csv");
            var sb = new StringBuilder();
            using (var streamWriter = new StringWriter(sb))
            using (var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
            {
               
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












        }
    }

