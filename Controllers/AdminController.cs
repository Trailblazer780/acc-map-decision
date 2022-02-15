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

        public IActionResult AllCourses() {
            // construction of the model
            Admin = new AdminModel(HttpContext);
            // if not logged in send user back to home page
            if (HttpContext.Session.GetString("auth") != "true"){
                return RedirectToAction("Index", "Home");
            }
            return View("AllCourses", Admin);
        }

        public IActionResult AllSemesters() {
            // construction of the model
            Admin = new AdminModel(HttpContext);
            // if not logged in send user back to home page
            if (HttpContext.Session.GetString("auth") != "true"){
                return RedirectToAction("Index", "Home");
            }
            return View("AllSemesters", Admin);
        }


        [HttpPost]
        public IActionResult ViewCourse(int id, string code, string name, string description, string rationale) {
            // construction of the model
            Admin = new AdminModel(HttpContext);
            // if not logged in send user back to home page
            if (HttpContext.Session.GetString("auth") != "true"){
                return RedirectToAction("Index", "Home");
            }
            Course course = new Course();
            course.id = id;
            course.course_code = code;
            course.course_name = name;
            course.course_description = description;
            course.course_rationale = rationale;
            return View("ViewCourse", course);
        }

        [HttpPost]
        public IActionResult EditCourse(int id, string code, string name, string description, string rationale) {
            // construction of the model
            Admin = new AdminModel(HttpContext);
            // if not logged in send user back to home page
            if (HttpContext.Session.GetString("auth") != "true"){
                return RedirectToAction("Index", "Home");
            }
            Course course = new Course();
            course.id = id;
            course.course_code = code;
            course.course_name = name;
            course.course_description = description;
            course.course_rationale = rationale;

            return View("EditCourse", course);
        }

        public IActionResult EditCourseSubmit(int id, string code, string name, string description, string rationale) {
            // construction of the model
            Admin = new AdminModel(HttpContext);
            // if not logged in send user back to home page
            if (HttpContext.Session.GetString("auth") != "true"){
                return RedirectToAction("Index", "Home");
            }

            Course course = new Course();
            course.id = id;
            course.course_code = code;
            course.course_name = name;
            course.course_description = description;
            course.course_rationale = rationale;

            return View("AllCourses", Admin);
        }


        [HttpPost]
        public IActionResult DeleteCourse(int id, string code, string name, string description, string rationale) {
            Admin = new AdminModel(HttpContext);
            // if not logged in send user back to home page
            if (HttpContext.Session.GetString("auth") != "true"){
                return RedirectToAction("Index", "Home");
            }
            Course course = new Course();
            course.id = id;
            course.course_code = code;
            course.course_name = name;
            course.course_description = description;
            course.course_rationale = rationale;
            return View("DeleteCourse", course);
        }

        [HttpPost]
        public IActionResult DeleteCourseSubmit(int id){
            Admin = new AdminModel(HttpContext);
            // if not logged in send user back to home page
            if (HttpContext.Session.GetString("auth") != "true"){
                return RedirectToAction("Index", "Home");
            }
            Console.WriteLine("Deleting course with id: " + id);
            
            Course deleteCourse = new Course();
            deleteCourse.id = id;
            Admin.Remove(deleteCourse);
            Admin.SaveChanges();

            return RedirectToAction("Index", Admin);
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