using projetDotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projetDotNet.Controllers
{
    public class StudentController : Controller
    {
        TekupContext myDB = new TekupContext();

        public ActionResult Index()
        {
            List<Student> studentList = new List<Student>();
            studentList = (from student in myDB.students select student).ToList();
            return View(studentList);
        }
        public ActionResult GetStudent(int id)
        {
            Student s = new Student();
            s = (from obj in myDB.students
                    where obj.studentID == id
                    select obj).FirstOrDefault();
            return View("studentDetails");
        }
        [HttpGet]
        public ActionResult InsertStudent()
        {

            return View("InsertStudent");

        }
        [HttpPost]
        public ActionResult InsertStudent(Student student )
        {
            myDB.students.Add(student);
            myDB.SaveChanges();
            return RedirectToAction("Index");
           
        }
        [HttpGet]
        public ActionResult UpdateStudent(int id)
        {
            Student s = new Student();
            s = (from obj in myDB.students
                 where obj.studentID == id
                 select obj).FirstOrDefault();
            return View("UpdateStudent", s);
        }
        [HttpPost]
        public ActionResult UpdateStudent(int id, Student s)
        {
            var student = myDB.students.FirstOrDefault(stu => stu.studentID == id);
            student.studentName = s.studentName;
            student.studentNbr = s.studentNbr;
            myDB.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteStudent(int id)
        {
            Student s = new Student();
            s = (from obj in myDB.students
                 where obj.studentID == id
                 select obj).FirstOrDefault();
            myDB.students.Remove(s);
            myDB.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}