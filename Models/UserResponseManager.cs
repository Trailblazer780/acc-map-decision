using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;  
namespace accmapdecision.Models {

    public class UserResponseManager : DbContext  {

        private DbSet<Course> tblCourse {get; set;}
        private DbSet<Question> tblQuestion {get; set;}
        private DbSet<Option> tblOption {get; set;}
        private DbSet<Semester> tblSemester {get; set;}

        public UserResponse userResponse {get; set;} = new UserResponse();
        public bool isQuestionsPopulated {get; set;} = false;
        private string _userResponseState;
    
        private QuestionModel _currentQuestion;
        private SemesterCourseMap _currentSemester;

        private int _currentQuestionID;
        private int _currentSemesterID;

        public QuestionModel currentQuestion {
            get {
                return _currentQuestion;
            }
            set {
                _currentQuestion = value;
            }
        }

        public SemesterCourseMap currentSemester {
            get {
                return _currentSemester;
            }
            set {
                _currentSemester = value;
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
        
        public int currentSemesterID {
            get {
                return _currentSemesterID;
            }
            set {
                _currentSemesterID = value;
            }
        }

        public string userResponseState {
            get {
                return JsonConvert.SerializeObject(userResponse);               
            }
            set {
                userResponse = JsonConvert.DeserializeObject<UserResponse>(value);
            }
        }

        // Fetch Questions, options and courses from the database and populate userResponseModel Questions
        public void populateUserResponseModel() {

            
            List<Question> questionsFromDb = tblQuestion.OrderBy(q => q.questionID)
                                                        .Include(q => q.optionsList)
                                                        .ThenInclude(o => o.courses)
                                                        .ThenInclude(c => c.requisites)
                                                        .ToList();

            List<QuestionModel> questionsList = new List<QuestionModel>();
            foreach(Question question in questionsFromDb) {
                QuestionModel questionModel = new QuestionModel(question.questionID, question.questionText, question.questionDescription);
                // Console.WriteLine(questionModel);
                foreach(Option option in question.optionsList) {
                    OptionModel optionModel = new OptionModel(option.optionID, option.optionText, option.nextQuestionId);
                    foreach(Course course in option.courses) {
                        CourseModel courseModel = new CourseModel(course.id, course.course_code, course.course_name, course.course_units);

                        foreach(Requisite requisite in course.requisites) {
                            courseModel.preRequisites.Add(new CourseModel(requisite.requiredCourse.id, requisite.requiredCourse.course_code, requisite.requiredCourse.course_name, requisite.requiredCourse.course_units));
                        }

                        optionModel.courses.Add(courseModel);
                        // Console.WriteLine(courseModel);
                    }
                    // Console.WriteLine(optionModel);
                    questionModel.optionsList.Add(optionModel);
                }
                questionsList.Add(questionModel);
            }


            userResponse.questionsAndResponses = questionsList;
            _currentQuestion = questionsList.First();

            isQuestionsPopulated = true;
        }


        // Fetch semesters and courses from the database and populate programCourseMap 
        public void populateProgramCourseMap() {
            
            List<Semester> semestersFromDb = tblSemester.OrderBy(q => q.semester_id).Include(q => q.courses).ThenInclude(o => o.requisites).ToList();

            ProgramCourseMap programCourseMap = new ProgramCourseMap();

            foreach(Semester semester in semestersFromDb) {
                SemesterCourseMap semesterCourseMap = new SemesterCourseMap();
                semesterCourseMap.semesterId        = semester.semester_id;
                semesterCourseMap.semesterTitle     = semester.semester_code;
                semesterCourseMap.coursesSelected   = new List<CourseModel>();
                semesterCourseMap.eligibleCourses   = new List<CourseModel>();

                ICollection<Course> semesterCourses = semester.courses;

                foreach(Course course in semesterCourses) {
                    // Add to semester eligible courses if present in coursesToInclude based on Q&A
                    if(userResponse.coursesToInclude.Where(c => c.courseID == course.id).Count() > 0) {
                        semesterCourseMap.eligibleCourses.Add(userResponse.coursesToInclude.Where(c => c.courseID == course.id).FirstOrDefault());
                    }
                }
                
                programCourseMap.semesterList.Add(semesterCourseMap);
            }
            userResponse.programCourseMap = programCourseMap;
        }

        // Process the option selected by the user for each question
        public bool processUserResponse(int selectedOptionId, int currentQuestionID) {
            bool isLastQuestion = false;

            if(!this.isQuestionsPopulated){
                this.populateUserResponseModel();
                this.currentQuestionID = 1;
                isLastQuestion = false;
            }

            if(selectedOptionId == 0 || selectedOptionId == 11 ) {     // // Temporary: Handling error for First request or selected ALP-AU
                this.populateUserResponseModel();
                this.currentQuestionID = 1;
                isLastQuestion = false;
            } else {

                // Fetch current question object
                QuestionModel currentQuestion = this.userResponse.questionsAndResponses.Find(x => x.questionID == currentQuestionID);
                int currentQuestionIndex = this.userResponse.questionsAndResponses.FindIndex(x => x.questionID == currentQuestionID);

                // Fetch selected option object
                OptionModel optionSelected = currentQuestion.optionsList.First(x => x.optionID == selectedOptionId);
                
                // Update list of courses
                this.userResponse.coursesToInclude.AddRange(optionSelected.courses);
                this.userResponse.coursesRemaining.AddRange(optionSelected.courses);

                // Add to total course units
                foreach(CourseModel courseToInclude in optionSelected.courses) {
                    this.userResponse.totalCourseUnits += courseToInclude.courseUnits;
                }

                // Update current question object with selected option
                currentQuestion.selectedOptionId = optionSelected.optionID;
                currentQuestion.selectedOptionText = optionSelected.optionText;
                this.userResponse.questionsAndResponses[currentQuestionIndex] = currentQuestion;

                // Fetch next question based on nextQuestionId
                if(optionSelected.nextQuestionId != 0) {
                    QuestionModel nextQuestion = this.userResponse.questionsAndResponses.Find(x => x.questionID == optionSelected.nextQuestionId);

                    // Set next question as current question and return the model
                    // Check for end of questions                    
                    this.currentQuestionID = optionSelected.nextQuestionId;
                    this.currentQuestion = nextQuestion;
                    isLastQuestion = false;
                } else {    
                    // Handling end of questions
                    isLastQuestion = true;
                }
            }
            return isLastQuestion;
        }

        // Process the courses selected by user in each semester
        public bool processSemesterCourses(int currentSemesterIdParam, int switchToSemesterID, int[] selectedCourseIds) {
            bool isLastSemester = false;

            if(userResponse.programCourseMap.semesterList.Count == 0){
                populateProgramCourseMap();
                currentSemesterID = 1;
            } else {
                if(switchToSemesterID == 0) 
                    currentSemesterID = currentSemesterIdParam;
                else
                    currentSemesterID = switchToSemesterID;
            }

            this.currentSemester = userResponse.programCourseMap.semesterList.Where(s => s.semesterId == currentSemesterID).FirstOrDefault();
            int currentSemesterIndex = userResponse.programCourseMap.semesterList.FindIndex(s => s.semesterId == currentSemesterID);
            
            if(switchToSemesterID == 0 && (selectedCourseIds.Count() > 0 || this.currentSemester.eligibleCourses.Where(c => c.show).ToList().Count == 0)) {

                // Handing unchecked courses: Remove current semester courses and add again from the checked courses
                userResponse.coursesSelected = userResponse.coursesSelected.Except(currentSemester.coursesSelected).ToList();
                currentSemester.coursesSelected.RemoveAll(x => 1 == 1);
                
                foreach(int courseId in selectedCourseIds) {
                    CourseModel selectedCourse = userResponse.coursesToInclude.Where(x => x.courseID == courseId).FirstOrDefault();

                    // Process course if not already selected
                    if(!userResponse.coursesSelected.Contains(selectedCourse)) {
                        this.currentSemester.coursesSelected.Add(selectedCourse);
                        userResponse.coursesSelected.Add(selectedCourse);
                        userResponse.coursesRemaining.Remove(selectedCourse);
                    }
                }
                userResponse.programCourseMap.semesterList[currentSemesterIndex] = this.currentSemester;

                // Update currentSemester with next semester to show
                if(currentSemesterIdParam < 6) {
                    currentSemesterID = currentSemesterIdParam + 1;
                    this.currentSemester = userResponse.programCourseMap.semesterList.Where(s => s.semesterId == currentSemesterID).FirstOrDefault();
                } else {
                    isLastSemester = true;
                }

                // If nothing selected in the next semester, update the courses based on pre-requisites and already selected list
                if(currentSemester.coursesSelected.Count == 0)
                    this.updateSemesterEligibleCoursesList();
            }

            // foreach(SemesterCourseMap semesterCourseMap in userResponse.programCourseMap.semesterList) {
            //     Console.WriteLine("\n^^");
            //     Console.WriteLine(semesterCourseMap.semesterTitle);
            //     foreach(CourseModel courseModel in semesterCourseMap.coursesSelected) {
            //         Console.WriteLine(courseModel.courseCode);
            //     }
            //     Console.WriteLine("\n^^");
            // }
                

            // Console.WriteLine("-----------------------------------------");
            // Console.WriteLine(currentSemesterIdParam);
            // Console.WriteLine(currentSemesterID);
            // Console.WriteLine(currentSemester);
            // Console.WriteLine(userResponse.programCourseMap.semesterList.Count);
            // Console.WriteLine("-----------------------------------------");

            return isLastSemester;
        }


        // -------------------------------------------------- private methods

        // Use selected courses from userResponse and update current sem eligible courses based on selected and prerequisites
        // hide if already selected
        // show if all prerequisites are selected
        private void updateSemesterEligibleCoursesList() {
            int index = 0;
            foreach(CourseModel courseModel in this.currentSemester.eligibleCourses.ToList()) {
                if(userResponse.coursesSelected.Contains(courseModel)) {
                    courseModel.show = false;
                } 

                // If all pre-requisites are selected, set show = true
                else if(courseModel.preRequisites.Intersect(userResponse.coursesSelected).Count() == courseModel.preRequisites.Count()) {
                    courseModel.show = true;
                } else {
                    courseModel.show = false;
                }

                this.currentSemester.eligibleCourses[index] = courseModel;
                index++;
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseMySql(Connection.CONNECTION_STRING, new MySqlServerVersion(new Version(8, 0, 11)));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            // Semester
            modelBuilder.Entity<Semester>().HasMany(p => p.courses).WithMany(p => p.semesters).UsingEntity<CourseOffered>(
            j => j.HasOne(pt => pt.course).WithMany(t => t.courseOffered).HasForeignKey(pt => pt.course_id),
            j => j.HasOne(pt => pt.semester).WithMany(p => p.courseOffered).HasForeignKey(pt => pt.semester_id)
            );
            modelBuilder.Entity<CourseOffered>().HasKey(bc => new { bc.semester_id, bc.course_id });

            // Course -Requisites
            modelBuilder.Entity<Requisite>().HasKey(bc => new { bc.course_id, bc.required_course_id });

            modelBuilder.Entity<Course>()
                        .HasMany<Requisite>(s => s.requisites)
                        .WithOne(a => a.course)
                        .HasForeignKey(ad => ad.course_id);

            modelBuilder.Entity<Requisite>()
                        .HasOne<Course>(s => s.requiredCourse)
                        .WithMany(a => a.requisites2)
                        .HasForeignKey(ad => ad.required_course_id)
                        .OnDelete(DeleteBehavior.Restrict);

            // Question - Option
            modelBuilder.Entity<Option>()
                        .HasOne<Question>(s => s.question)
                        .WithMany(g => g.optionsList)
                        .HasForeignKey(s => s.questionId);

            modelBuilder.Entity<Option>()
                        .HasOne<Question>(s => s.nextQuestion)
                        .WithMany()
                        .HasForeignKey(s => s.nextQuestionId);

            
            // Option - Course mapping
            modelBuilder.Entity<OptionCourseMapping>().HasKey(oc => new { oc.courseId, oc.optionId });

            modelBuilder.Entity<Option>().HasMany(p => p.courses).WithMany(p => p.options).UsingEntity<OptionCourseMapping>(
                j => j.HasOne(pt => pt.course).WithMany(t => t.optionCourseMapping).HasForeignKey(pt => pt.courseId),
                j => j.HasOne(pt => pt.option).WithMany(p => p.optionCourseMapping).HasForeignKey(pt => pt.optionId)
            );

        }

    }

}