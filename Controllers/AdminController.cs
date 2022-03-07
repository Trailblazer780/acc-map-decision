using System;
using Microsoft.AspNetCore.Mvc;
using accmapdecision.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;



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
        public IActionResult AllQuestions(){
            // if not logged in send user back to home page
            if (HttpContext.Session.GetString("auth") != "true"){
                return RedirectToAction("Index", "Home");
            }
            Admin = new AdminModel(HttpContext);
            return View("AllQuestions", Admin);
        }

        // --------------------------------------------------- Course ---------------------------------------------------
        [HttpPost]
        public IActionResult ViewCourse(int id) {
            // construction of the model
            Admin = new AdminModel(HttpContext);
            // if not logged in send user back to home page
            if (HttpContext.Session.GetString("auth") != "true"){
                return RedirectToAction("Index", "Home");
            }

            Course courseReq = Admin.getCourseRequisites(id);

            Console.WriteLine(courseReq.requisites.Count);
            // loop through the requisites and add them to the model
            foreach (Requisite requisite in courseReq.requisites) {
               Console.WriteLine(requisite.requiredCourse.course_code);
            }

            return View("ViewCourse", courseReq);
        }



        // int id, string code, string name, string description, string rationale
        [HttpPost]
        public IActionResult EditCourse(int id, string code, string name, string description, string rationale) {
            // construction of the model
            Admin = new AdminModel(HttpContext);
            // if not logged in send user back to home page
            if (HttpContext.Session.GetString("auth") != "true"){
                return RedirectToAction("Index", "Home");
            }
            // Course course = new Course();
            Course courseReq = Admin.getCourseRequisites(id);
            ViewBag.allCourses = Admin.getAllCourses();

            return View("EditCourse", courseReq);
        }
        // int id, string code, string name, string description, string rationale
        [HttpPost]
        public IActionResult EditCourseSubmit(Course course, string[] courses) {
            // construction of the model
            Admin = new AdminModel(HttpContext);
            // if not logged in send user back to home page
            if (HttpContext.Session.GetString("auth") != "true"){
                return RedirectToAction("Index", "Home");
            }

            List<Requisite> selectedRequisites = new List<Requisite>();

            for(int i = 0; i < courses.Length; i++){
                Requisite courseReq = new Requisite();
                courseReq.requiredCourse = Admin.getCourse(Int32.Parse(courses[i]));
                courseReq.course = course;
                courseReq.type = 0;
                courseReq.condition = 1;
                Admin.Attach(courseReq);
                selectedRequisites.Add(courseReq);
            }

            if(ModelState.IsValid) {
                Admin.Database.ExecuteSqlRaw("DELETE FROM tblRequisite WHERE type = 0 AND course_id = " + course.id);
                course.requisites = selectedRequisites;
                // Admin.Database.
                Admin.Update(course);
                Admin.SaveChanges();
                return RedirectToAction("AllCourses", Admin);
            } 
            else{
                return View("EditCourse", course);
            }
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

            return RedirectToAction("AllCourses");
        }

        // --------------------------------------------------- Semester ---------------------------------------------------
        [HttpPost]
        public IActionResult ViewSemester(int id, string code) {
            // if not logged in send user back to home page
            if (HttpContext.Session.GetString("auth") != "true"){
                return RedirectToAction("Index", "Home");
            }
            // construction of the model
            Admin = new AdminModel(HttpContext);
            Semester semester = Admin.getSemester(id);

            return View("ViewSemester", semester);
        }

        [HttpPost]
        public IActionResult EditSemester(int id, string code){
            // if not logged in send user back to home page
            if (HttpContext.Session.GetString("auth") != "true"){
                return RedirectToAction("Index", "Home");
            }
            Admin = new AdminModel(HttpContext);
            Semester semester = Admin.getSemester(id);
            ViewBag.allCourses = Admin.getAllCourses(); 
            semester.semester_id = id;
            semester.semester_code = code;
            return View(semester);
        }

        [HttpPost]
        public IActionResult EditSemesterSubmit(Semester semester, String[] courses){
            // if not logged in send user back to home page
            if (HttpContext.Session.GetString("auth") != "true"){
                return RedirectToAction("Index", "Home");
            }
            Admin = new AdminModel(HttpContext);
            List<Course> selectedCourses = new List<Course>();

            for(int i = 0; i < courses.Length; i++){
                Course course = Admin.getCourse(Int32.Parse(courses[i]));
                course.id = Int32.Parse(courses[i]);
                Admin.Attach(course);
                selectedCourses.Add(course);
            }

            if(ModelState.IsValid) {
                Admin.Database.ExecuteSqlRaw("DELETE FROM tblCourse_semester WHERE semester_id = " + semester.semester_id);
                // Admin.Database.
                semester.courses = selectedCourses;
                Admin.Update(semester);
                Admin.SaveChanges();
                return RedirectToAction("AllSemesters", Admin);
            } 
            else{
                return View("EditSemester", semester);
            }
        }

        [HttpPost]
        public IActionResult DeleteSemester(int id, string code) {
            // if not logged in send user back to home page
            if (HttpContext.Session.GetString("auth") != "true"){
                return RedirectToAction("Index", "Home");
            }
            Admin = new AdminModel(HttpContext);
            Semester semester = new Semester();
            semester.semester_id = id;
            semester.semester_code = code;

            return View("DeleteSemester", semester);
        }
        
        [HttpPost]
        public IActionResult DeleteSemesterSubmit(int id, string code) {
            // if not logged in send user back to home page
            if (HttpContext.Session.GetString("auth") != "true"){
                return RedirectToAction("Index", "Home");
            }
            Admin = new AdminModel(HttpContext);
            Semester semester = new Semester();
            semester.semester_id = id;
            semester.semester_code = code;
            Admin.Remove(semester);
            Admin.SaveChanges();
            return RedirectToAction("AllSemesters");
        }

        // --------------------------------------------------- Questions ---------------------------------------------------




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