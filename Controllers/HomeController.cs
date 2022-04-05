using System;
using Microsoft.AspNetCore.Mvc;
using accmapdecision.Models;
using System.IO;
using System.Globalization;
using CsvHelper;
using System.Collections.Generic;
using System.Linq;

namespace accmapdecision.Controllers {

    public class HomeController : Controller {

        private UserResponseManager userResponseManager;

        public HomeController(UserResponseManager userResponseManager) {
            this.userResponseManager = userResponseManager;
        }

        public IActionResult IndexCSV() {
            CSVModel csv = new CSVModel();
            // csv.WriteCSV();

            return View();
        }

        public IActionResult Index(UserResponseManager userResponseManagerModel, int selectedOptionId, int currentQuestionID) {
            this.userResponseManager = userResponseManagerModel;

            if(userResponseManager.processUserResponse(selectedOptionId, currentQuestionID)) {
                // Return decision view if questions ended
                return View("Decision", userResponseManager);
            }

            return View(userResponseManager);
        }

        [HttpPost]
        public IActionResult SelectCourses(UserResponseManager userResponseManagerModel, int currentSemesterID, int switchToSemesterID, int[] selectedCourses) {
            this.userResponseManager = userResponseManagerModel;

            bool isFirstRequest = false;
            if(userResponseManager.userResponse.programCourseMap.semesterList.Count == 0) {
                isFirstRequest = true;
            }

            if(userResponseManager.processSemesterCourses(currentSemesterID, switchToSemesterID, selectedCourses)) {
                // Return decision view if questions ended
                return View("FinalProgramMap", userResponseManager);
            }    

            if(!isFirstRequest && userResponseManager.errorMessage != "") {
                ViewBag.errorMessage = userResponseManager.errorMessage;
            } else {
                ViewBag.errorMessage = "";
            }

            return View(userResponseManager);
        }

    }
}
