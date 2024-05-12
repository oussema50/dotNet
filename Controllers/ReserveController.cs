using projetDotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projetDotNet.Controllers
{
    public class ReserveController : Controller
    {
        TekupContext myDB = new TekupContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ReserveCourse(int id)
        {

            var course = myDB.courses.FirstOrDefault(cour => cour.courseID == id);
            return View("ReserveCourse",course);
        }
    }
}