using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Globalization;
using CsvHelper;

namespace accmapdecision.Models {

    public class CSVModel : DbContext {

        public CSVModel() {
        }
        // public void WriteCSV(UserResponse userResponse) {
        public void WriteCSV(List<Course> courses) {
            var csvPath = Path.Combine(Environment.CurrentDirectory, $"courses-{DateTime.Now.ToFileTime()}.csv");
            using (var streamWriter = new StreamWriter(csvPath)) {
            using (var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture)) { 
                // var userResponse = UserResponseManager;
                // csvWriter.WriteRecords(userResponse.questionsAndResponses);
                csvWriter.WriteRecords(courses);
                // Exports all the courses in allCourses for now
            }
        } Console.WriteLine("CSV File Created");
        }

    }
}
