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

        // --------------------------------------------------- Course ---------------------------------------------------
        [HttpPost]
        public IActionResult ViewCourse(int id, string code, string name, string description, string rationale) {
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


            // Course course = new Course();
            // course.id = id;
            // course.course_code = code;
            // course.course_name = name;
            // course.course_description = description;
            // course.course_rationale = rationale;
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
            Course course = new Course();
            course.id = id;
            course.course_code = code;
            course.course_name = name;
            course.course_description = description;
            course.course_rationale = rationale;

            return View(course);
        }
        // int id, string code, string name, string description, string rationale
        [HttpPost]
        public IActionResult EditCourseSubmit(Course course) {
            // construction of the model
            Admin = new AdminModel(HttpContext);
            // if not logged in send user back to home page
            if (HttpContext.Session.GetString("auth") != "true"){
                return RedirectToAction("Index", "Home");
            }
            if(ModelState.IsValid) {
                Admin.Update(course);
                Admin.SaveChanges();
                return RedirectToAction("AllCourses", Admin);
            } 
            else{
                return View("EditCourse", course);
            }
            // return RedirectToAction("AllCourses", Admin);
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
            // Console.WriteLine("id: " + id);
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

            // Console.WriteLine("course count: " + selectedCourses.Count);
            
            // Console.WriteLine("id: " + semester.semester_id);
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