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

        // public CSVModel() {
        // }

        // public void WriteCSV(UserResponse userResponse) {
        public void WriteCSV(List<Course> courses) {

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
                foreach (var course in courses)
                {
                    csvWriter.WriteField(course.course_code);
                    csvWriter.WriteField(course.course_name);
                    csvWriter.WriteField(course.course_description);
                    // csvWriter.WriteField(course.course_rationale);
                    csvWriter.NextRecord();
                }
                File.WriteAllText(csvPath, sb.ToString(), Encoding.Default);                
                // Exports all the courses in allCourses for now
                // Console.WriteLine(csvPath); 
                csvWriter.Flush();
            }
        Console.WriteLine("CSV File Created");
        } 
        // return csvPath;
        }


    }

