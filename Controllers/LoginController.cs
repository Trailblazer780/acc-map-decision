using System;
using Microsoft.AspNetCore.Mvc;
using accmapdecision.Models;
using Microsoft.AspNetCore.Http;

namespace accmapdecision.Controllers {

    public class LoginController : Controller {

        public IActionResult Index() {
            return View();
        }

        public IActionResult Submit(string myUsername, string myPassword) {
            // Construction of the model
            WebLoginModel webLogin = new WebLoginModel(Connection.CONNECTION_STRING, HttpContext);
            // setting username and password
            webLogin.username = myUsername;
            webLogin.password = myPassword;
            Console.WriteLine(">>> Username: " + myUsername);
            Console.WriteLine(">>> Password: " + myPassword);
            // redirect to admin if login is successful
            if(webLogin.Login()){
                return RedirectToAction("Index", "Admin");
            }
            else{
                // Dislay error message
                TempData["feedback"] = "Incorrect login. Please try again...";
                return View("Index");
            }
        }

    }
}
