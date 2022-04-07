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
            // CSVModel csv = new CSVModel();
            // csv.WriteCSV(); 

            return View();
        }

        public IActionResult Index(UserResponseManager userResponseManagerModel, int selectedOptionId, int currentQuestionID) {
            this.userResponseManager = userResponseManagerModel;
<<<<<<< HEAD
            
            if(!userResponseManager.isQuestionsPopulated){
                userResponseManager.populateUserResponseModel();
                userResponseManager.currentQuestionID = 1; 
            }


            if(selectedOptionId == 0) {     // First request
=======
>>>>>>> cff145e23abc0dc08d8e5d73b27e068b05406e06

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
<<<<<<< HEAD
            
            // if(currentQuestionID==2) { // supposed to be 3 but it throws an error
            //     CSVModel csv = new CSVModel();
            //     csv.WriteCSV(userResponseManager.userResponse);
            // Once we fix the user response error we'll add an option to export the data after answering questions
            // }
=======
>>>>>>> cff145e23abc0dc08d8e5d73b27e068b05406e06

            return View(userResponseManager);
        }

    }
}
