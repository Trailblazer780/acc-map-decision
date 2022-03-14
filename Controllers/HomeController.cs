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
            
            if(!userResponseManager.isQuestionsPopulated){
                userResponseManager.populateUserResponseModel();
                userResponseManager.currentQuestionID = 1;
            }

            if(selectedOptionId == 0 || selectedOptionId == 11 ) {     // // Temporary: Handling error for First request or selected ALP-AU
                userResponseManager.populateUserResponseModel();
                userResponseManager.currentQuestionID = 1;
            } else {

                // Fetch current question object
                QuestionModel currentQuestion = userResponseManager.userResponse.questionsAndResponses.Find(x => x.questionID == currentQuestionID);
                int currentQuestionIndex = userResponseManager.userResponse.questionsAndResponses.FindIndex(x => x.questionID == currentQuestionID);

                // Fetch selected option object
                OptionModel optionSelected = currentQuestion.optionsList.First(x => x.optionID == selectedOptionId);
                
                // Update list of courses
                userResponseManager.userResponse.coursesToInclude.AddRange(optionSelected.courses);

                // Add to total course units
                foreach(CourseModel courseToInclude in optionSelected.courses) {
                    userResponseManager.userResponse.totalCourseUnits += courseToInclude.courseUnits;
                }

                // Update current question object with selected option
                currentQuestion.selectedOptionId = optionSelected.optionID;
                currentQuestion.selectedOptionText = optionSelected.optionText;
                userResponseManager.userResponse.questionsAndResponses[currentQuestionIndex] = currentQuestion;

                // Fetch next question based on nextQuestionId
                if(optionSelected.nextQuestionId != 0) {
                    QuestionModel nextQuestion = userResponseManager.userResponse.questionsAndResponses.Find(x => x.questionID == optionSelected.nextQuestionId);

                    // Set next question as current question and return the model
                    // Check for end of questions                    
                    userResponseManager.currentQuestionID = optionSelected.nextQuestionId;
                    userResponseManager.currentQuestion = nextQuestion;
                } else {    
                    // Handling end of questions
                    return View("Decision", userResponseManager);
                }

                // Console.WriteLine(userResponseManager.userResponse);
            }

            return View(userResponseManager);
        }

        [HttpPost]
        public IActionResult SelectCourses(UserResponseManager userResponseManagerModel) {
            this.userResponseManager = userResponseManagerModel;
            // userResponseManager.populateProgramCourseMap();

            return View(userResponseManager);
        }

    }
}
