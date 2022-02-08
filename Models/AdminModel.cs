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

        public List<Course> course {
            get {
                return tblCourse.OrderBy(i => i.id).ToList();
            }
        }

        public void Logout() {
            // logout the user by clearing the session
            context.Session.Clear();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseMySql(Connection.CONNECTION_STRING, new MySqlServerVersion(new Version(8, 0, 11)));
        }
    }
}