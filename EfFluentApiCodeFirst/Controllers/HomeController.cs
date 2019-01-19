using EfFluentApiCodeFirst.Models.Manager;
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

            return View();
        }
    }
}