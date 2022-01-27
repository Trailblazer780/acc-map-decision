using System;
using Microsoft.AspNetCore.Mvc;
using accmapdecision.Models;

namespace accmapdecision.Controllers {

    public class HomeController : Controller {

        public IActionResult Index() {
            return View();
        }

    }
}
