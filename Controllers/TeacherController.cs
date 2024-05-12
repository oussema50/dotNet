using projetDotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projetDotNet.Controllers
{
    public class TeacherController : Controller
    {
        TekupContext myDB = new TekupContext();
       
        public ActionResult Index()
        {
            List<Teacher> teacherList = new List<Teacher>();
            teacherList = (from teacher in myDB.teachers select teacher).ToList();
            return View(teacherList);
        }
        [HttpGet]
        public ActionResult InsertTeacher()
        {

            return View("InsertTeacher");
        }
        [HttpPost]
        public ActionResult InsertTeacher(Teacher teacher)
        {
            myDB.teachers.Add(teacher);
            myDB.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateTeacher(int id)
        {
            Teacher teacher = new Teacher();
            teacher = (from obj in myDB.teachers
                       where obj.teacherID == id
                       select obj).FirstOrDefault();

            return View("UpdateTeacher",teacher);
        }
        [HttpPost]
        public ActionResult UpdateTeacher(int id,Teacher t)
        {
            var teacher = myDB.teachers.FirstOrDefault(teach => teach.teacherID == id);
            teacher.teacherName = t.teacherName;
            teacher.teacherNbr = t.teacherNbr;
            myDB.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult DeleteTeacher(int id)
        {
            Teacher teacher = new Teacher();
            teacher = (from obj in myDB.teachers
                    where obj.teacherID == id
                    select obj).FirstOrDefault();
            myDB.teachers.Remove(teacher);
            myDB.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}