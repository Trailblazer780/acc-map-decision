using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using CsvHelper;
using System.IO;
using System.Globalization;

namespace accmapdecision
{
    public class Program
    {
        public static void Main(string[] args) {
            WriteCSV();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });


            public static void WriteCSV() {
                var csvPath = Path.Combine(Environment.CurrentDirectory, $"courses-{DateTime.Now.ToFileTime()}.csv");
                
                using (var streamWriter = new StreamWriter(csvPath)) {
                using (var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture)) { 
                    // Change this to database or connect GetCourses() to database
                    var courses = CourseInfo.GetCourses();
                    csvWriter.WriteRecords(courses);
                }
            }
            Console.WriteLine("CSV File Created");
            }


    }
}
