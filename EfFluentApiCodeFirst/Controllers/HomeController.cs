using EfFluentApiCodeFirst.Models.Manager;
using EfFluentApiCodeFirst.Models.OneToMany;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EfFluentApiCodeFirst.Controllers
{
    public class HomeController : Controller
    {
        DatabaseContext db = new DatabaseContext();

        public ActionResult Index()
        {
            var students = db.Student.ToList();
            var studentsAddresses = db.StudentAddress.ToList();

            var aysel = db.Teacher.Where(x => x.Name == "aysel").FirstOrDefault();
            var ayselsLessons = db.Lessons.Where(x => x.Teacher.Name == "aysel").ToList();


            return View();
        }
    }
}