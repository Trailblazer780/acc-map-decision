using System;
using Microsoft.AspNetCore.Mvc;
using accmapdecision.Models;
using System.IO;
using System.Globalization;
using CsvHelper;
using System.Collections.Generic;

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

            if(selectedOptionId == 0) {     // First request

            } else {
                Console.WriteLine("\n\nSelected Option: " + selectedOptionId);
                Console.WriteLine(currentQuestionID + " QID");

                // Fetch current question object
                Question currentQuestion = userResponseManager.userResponse.questionsAndResponses.Find(x => x.questionID == currentQuestionID);
                int currentQuestionIndex = userResponseManager.userResponse.questionsAndResponses.FindIndex(x => x.questionID == currentQuestionID);

                // Fetch selected option object
                Option optionSelected = currentQuestion.optionsList.Find(x => x.optionID == selectedOptionId);

                // Update current question object with selected option
                currentQuestion.optionSelected = optionSelected;
                userResponseManager.userResponse.questionsAndResponses[currentQuestionIndex] = currentQuestion;

                // Fetch next question based on nextQuestionId
                Question nextQuestion = userResponseManager.userResponse.questionsAndResponses.Find(x => x.questionID == optionSelected.nextQuestionId);

                // Set next question as current question and return the model
                userResponseManager.currentQuestionID = optionSelected.nextQuestionId;
                userResponseManager.currentQuestion = nextQuestion;
            }
            
            return View(userResponseManager);
        }

    }
}
