using System;
using Microsoft.AspNetCore.Mvc;
using accmapdecision.Models;
using Microsoft.AspNetCore.Http;

namespace accmapdecision.Controllers {

    public class AdminController : Controller {

        private AdminModel Admin;

        public IActionResult Index() {
            // construction of the model
            Admin = new AdminModel(HttpContext);
            // if not logged in send user back to home page
            if (HttpContext.Session.GetString("auth") != "true"){
                return RedirectToAction("Index", "Home");
            }
            return View("Index", Admin);
        }

        public IActionResult Courses() {
            // construction of the model
            Admin = new AdminModel(HttpContext);
            // if not logged in send user back to home page
            if (HttpContext.Session.GetString("auth") != "true"){
                return RedirectToAction("Index", "Home");
            }
            return View("Courses", Admin);
        }

        public IActionResult Semesters() {
            // construction of the model
            Admin = new AdminModel(HttpContext);
            // if not logged in send user back to home page
            if (HttpContext.Session.GetString("auth") != "true"){
                return RedirectToAction("Index", "Home");
            }
            return View("Semesters", Admin);
        }


        [HttpPost]
        public IActionResult Delete(){
            return View("Delete");
        }

        [HttpPost]
        public IActionResult Logout() {
            // construction of the model
            Admin = new AdminModel(HttpContext);
            // log the user out
            Admin.Logout();
            // return the view
            return RedirectToAction("Index", "Home");
        }
    }
}