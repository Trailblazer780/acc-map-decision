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

        public UserResponse userResponse {get; set;} = new UserResponse();
        public bool isQuestionsPopulated {get; set;} = false;
        private string _userResponseState;
    
        private QuestionModel _currentQuestion;

        private int _currentQuestionID;

        public QuestionModel currentQuestion {
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

        public string userResponseState {
            get {
                return JsonConvert.SerializeObject(userResponse);               
            }
            set {
                userResponse = JsonConvert.DeserializeObject<UserResponse>(value);
            }
        }

        public void populateUserResponseModel() {

            
            List<Question> questionsFromDb = tblQuestion.OrderBy(q => q.questionID).Include(q => q.optionsList).ThenInclude(o => o.courses).ToList();

            List<QuestionModel> questionsList = new List<QuestionModel>();
            foreach(Question question in questionsFromDb) {
                QuestionModel questionModel = new QuestionModel(question.questionID, question.questionText, question.questionDescription);
                Console.WriteLine(questionModel);
                foreach(Option option in question.optionsList) {
                    OptionModel optionModel = new OptionModel(option.optionID, option.optionText, option.nextQuestionId);
                    foreach(Course course in option.courses) {
                        CourseModel courseModel = new CourseModel(course.id, course.course_code);
                        optionModel.courses.Add(courseModel);
                        Console.WriteLine(courseModel);
                    }
                    Console.WriteLine(optionModel);
                    questionModel.optionsList.Add(optionModel);
                }
                questionsList.Add(questionModel);
            }


            userResponse.questionsAndResponses = questionsList;
            _currentQuestion = questionsList.First();

            isQuestionsPopulated = true;
        }

        // -------------------------------------------------- private methods
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