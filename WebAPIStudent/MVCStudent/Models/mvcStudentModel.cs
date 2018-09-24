using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCStudent.Models
{
    public class mvcStudentModel
    {
        public int id { get; set; }
        [Required(ErrorMessage ="Field Required")]
        public string name { get; set; }
        public string address { get; set; }
    }
}