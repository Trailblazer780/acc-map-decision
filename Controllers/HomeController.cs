using System;
using Microsoft.AspNetCore.Mvc;
using accmapdecision.Models;
using System.IO;
using System.Globalization;
using CsvHelper;

namespace accmapdecision.Controllers {

    public class HomeController : Controller {

        public IActionResult Index() {
            return View();
        }

    }
}
