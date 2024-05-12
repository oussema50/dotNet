using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace projetDotNet.Models
{
    public class Student
    {
        public Student()
        {
            this.Courses = new HashSet<Course>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int studentID {  get; set; }
        public string studentName { get; set; }
        public int studentNbr { get; set; }

        public ICollection<Course> Courses { get; set; }



    }
}