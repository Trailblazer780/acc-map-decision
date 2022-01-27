using System;
using System.ComponentModel.DataAnnotations;

namespace accmapdecision.Models {
    // class to use with the user
    public class User {
        // ------------------------------------- get/set methods
        [Key]
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
        public string salt { get; set; }
    }
}