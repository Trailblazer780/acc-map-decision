using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;  

namespace accmapdecision.Models {

    public class UserResponseManager : DbContext  {

        public UserResponse userResponse {get; set;} = new UserResponse();
        public bool isQuestionsPopulated {get; set;} = false;
        private string _userResponseState;

    
        private Question _currentQuestion;

        private int _currentQuestionID;

        public Question currentQuestion {
            get {
                return _currentQuestion;
            }
            set {
                _currentQuestion = value;
            }
        }

        public int currentQuestionID {
            get {
                return _currentQuestionID;
            }
            set {
                _currentQuestionID = value;
            }
        }

        public void populateUserResponseModel() {
            Question q1 = new Question();
            q1.questionID = 1;
            q1.questionText = "Are you thinking of taking ALP or ACC?";
            
            List<Option> options = new List<Option>();
            options.Add(new Option(1, "ALP - Adult Learning Program", 0));
            options.Add(new Option(2, "ACC - Academic and Career Connections", 2));
            q1.optionsList = options;


            Question q2 = new Question();
            q2.questionID = 2;
            q2.questionText = "Do I need to take Math?";
            
            List<Option> options2 = new List<Option>();
            options2.Add(new Option(3, "Yes", 3));
            options2.Add(new Option(4, "No", 4));
            q2.optionsList = options2;


            Question q3 = new Question();
            q3.questionID = 3;
            q3.questionText = "Do I require College Health Math?";
            
            List<Option> options3 = new List<Option>();
            options3.Add(new Option(5, "Yes", 5));
            options3.Add(new Option(6, "No", 6));
            q3.optionsList = options3;


            Question q4 = new Question();
            q4.questionID = 4;
            q4.questionText = "Do I need to take English?";
            
            List<Option> options4 = new List<Option>();
            options4.Add(new Option(7, "Yes", 7));
            options4.Add(new Option(8, "No", 8));
            q4.optionsList = options4;

            userResponse.questionsAndResponses.Add(q1);
            userResponse.questionsAndResponses.Add(q2);
            userResponse.questionsAndResponses.Add(q3);
            userResponse.questionsAndResponses.Add(q4);

            _currentQuestion = q1;
            isQuestionsPopulated = true;
        }

        public string userResponseState {
            get {
               return JsonConvert.SerializeObject(userResponse); 
            }
            set {
                userResponse = JsonConvert.DeserializeObject<UserResponse>(value);
            }
        }

        // -------------------------------------------------- private methods
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseMySql(Connection.CONNECTION_STRING, new MySqlServerVersion(new Version(8, 0, 11)));
        }

    }

}