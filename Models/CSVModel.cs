using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Globalization;
using CsvHelper;

namespace accmapdecision.Models {

    public class CSVModel : DbContext {

        public CSVModel(){

        }
        // Call the method when click on button
        public void WriteCSV(UserResponse userResponse) {
            var csvPath = Path.Combine(Environment.CurrentDirectory, $"courses-{DateTime.Now.ToFileTime()}.csv");
            using (var streamWriter = new StreamWriter(csvPath)) {
            using (var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture)) { 
                
                // Change this to database
                // var courses = CourseInfo.GetCourses();
                // var userResponse = UserResponseManager;
                // csvWriter.WriteRecords(userResponse.questionsAndResponses);
                csvWriter.WriteRecords(userResponse.questionsAndResponses);

            }
        } Console.WriteLine("CSV File Created");
        }

    }
}
