using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace projetDotNet.Models
{

    public class Teacher
    {
        public Teacher()
        {
            this.Courses = new HashSet<Course>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int teacherID { get; set; }
        public string teacherName { get; set; }
        public int teacherNbr { get; set; }
        public ICollection<Course> Courses { get; set; }


    }
}