using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace accmapdecision.Models {

    [Table("tblRequisite")]
    public class Requisite {
        [Key]
        public int course_id {get; set;}
        public int required_course_id {get; set;}
        public int type {get; set;} 
        public int condition {get; set;}

    }
}