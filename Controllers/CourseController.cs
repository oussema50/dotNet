using projetDotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projetDotNet.Controllers
{
    public class CourseController : Controller
    {
        TekupContext myDB = new TekupContext();
        public ActionResult Index()
        {
            List<Course> courseList = new List<Course>();
            courseList = (from course in myDB.courses select course).ToList();
            return View(courseList);
        }

        [HttpGet]
        public ActionResult InsertCourse()
        {

            return View("InsertCourse");
        }
        [HttpPost]
        public ActionResult InsertCourse(Course course)
        {

            myDB.courses.Add(course);
            myDB.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateCourse(int id)
        {
            Course course = new Course();
            course = (from obj in myDB.courses
                      where obj.courseID == id
                      select obj).FirstOrDefault();

            return View("UpdateCourse", course);
        }
        [HttpPost]
        public ActionResult UpdateCourse(int id, Course c)
        {
            var course = myDB.courses.FirstOrDefault(cour => cour.courseID == id);
            course.courseName = c.courseName;
            course.isAvailable = c.isAvailable;
            System.Diagnostics.Debug.WriteLine(c);
            myDB.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult DeleteCourse(int id)
        {
            Course course = new Course();
            course = (from obj in myDB.courses
                      where obj.courseID == id
                      select obj).FirstOrDefault();
            myDB.courses.Remove(course); 
            myDB.SaveChanges();
            return RedirectToAction("Index");
        }
      
        

    }
}