using System;
using Microsoft.AspNetCore.Mvc;
using accmapdecision.Models;
using System.IO;
using System.Globalization;
using CsvHelper;

namespace accmapdecision.Controllers {

    public class HomeController : Controller {

        public IActionResult Index() {
            CSVModel csv = new CSVModel();
            
            // csv.WriteCSV();

            return View();
        }

    }
}
