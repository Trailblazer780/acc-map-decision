using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace accmapdecision.Models {

    public class AdminModel : DbContext {
        
        private HttpContext context;

        public AdminModel(HttpContext myHttpContext) {
            context = myHttpContext;

        }

        private DbSet<Course> tblCourse {get; set;}
        private DbSet<Semester> tblSemester {get; set;}
        private DbSet<CourseOffered> tblCourse_semester {get; set;}

        public List<Course> course {
            get {
                return tblCourse.OrderBy(i => i.id).ToList();
            }
        }

        public List<Semester> semester {
            get {
                // return tblSemester.OrderBy(i => i.semester_id).ToList();
                var player =  tblSemester.OrderBy(i => i.semester_id).Include(one => one.courses).ToList();
                // Console.WriteLine("Semester: " + player.Count);
                var courses = player[0].courses.ToList();
                // courses.ForEach(i => Console.WriteLine(i.course_code));

                for(int i = 0; i < courses.Count; i++) {
                    // Console.WriteLine("Course id: " + courses[i].course_code);
                }
                return player;
            }
        }

        public List<CourseOffered> course_semester {
            get {
                return tblCourse_semester.OrderBy(i => i.course_id).ToList();
            }
        }

        public Semester getSemester(int id) {
            return tblSemester.Where(i => i.semester_id == id).Include(one => one.courses).FirstOrDefault();
        }

        public Course getCourse(int id){
            return tblCourse.Where(i => i.id == id).FirstOrDefault();
        }

        public Course getCourseRequisites(int id){
            return tblCourse.Where(i => i.id == id).Include(one => one.requisites).FirstOrDefault();
        }

        public List<Course> getAllCourses() {
            return tblCourse.OrderBy(i => i.id).ToList();
        }

        public void Logout() {
            // logout the user by clearing the session
            context.Session.Clear();
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

            // Requisites
            // modelBuilder.Entity<Course>().HasMany(p => p.requisites).UsingEntity<Requisite>(
            // j => j.HasOne(pt => pt.course).WithMany(t => t.courseOffered).HasForeignKey(pt => pt.course_id),
            // j => j.HasOne(pt => pt.semester).WithMany(p => p.courseOffered).HasForeignKey(pt => pt.semester_id)
            // );

            // modelBuilder.Entity<Requisite>().HasOne<Course>(s => s.course).WithMany(g => g.requisites).HasForeignKey(s => s.course_id);
            // modelBuilder.Entity<Requisite>().HasOne<Course>(s => s.course).WithMany(g => g.requisites);

            // modelBuilder.Entity<Requisite>().HasOne<Course>(s => s.requiredCourse).WithMany(g => g.requisites);

            // modelBuilder.Entity<Course>().HasMany<Requisite>(s => s.requisites).WithOne(g => g.requiredCourse).HasForeignKey(s => s.required_course_id);

            // modelBuilder.Entity<Course>().HasMany<Requisite>(s => s.requisites).WithOne(g => g.course).HasForeignKey(s => s.course_id);

            // modelBuilder.Entity<Requisite>().HasOne<Course>(s => s.requiredCourse).WithMany(g => g.requisites);


            // modelBuilder.Entity<Course>().HasMany(p => p.requisites).WithOne(p => p.course).HasForeignKey(s => s.course_id)(
            // j => j.HasOne(pt => pt.course).WithMany(t => t.requisites).HasForeignKey(pt => pt.course_id),
            // j => j.HasOne(pt => pt.requiredCourse).WithMany(p => p.requisites).HasForeignKey(pt => pt.required_course_id)
            // );



        }
    }
}