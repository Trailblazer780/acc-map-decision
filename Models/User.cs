using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace accmapdecision.Models {
    // class to use with the user
    [Table("tblUsers")]
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