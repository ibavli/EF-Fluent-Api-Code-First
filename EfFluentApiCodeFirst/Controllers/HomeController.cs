using EfFluentApiCodeFirst.Models.Manager;
using EfFluentApiCodeFirst.Models.ManyToMany;
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


            var xyzAuthors = db.AuthorsBooksMapping.Where(x => x.BookId == 1).Select(y => y.Author).ToList();

            var abcAuthors = db.AuthorsBooksMapping.Where(x => x.BookId == 2).Select(y => y.Author).ToList();


            var aliBooks = db.AuthorsBooksMapping.Where(x => x.AuthorId == 3).Select(y => y.Book).ToList();

            var ayseBooks = db.AuthorsBooksMapping.Where(x => x.AuthorId == 2).Select(y => y.Book).ToList();

            var hasanBooks = db.AuthorsBooksMapping.Where(x => x.AuthorId == 1).Select(y => y.Book).ToList();



            return View();
        }
    }
}