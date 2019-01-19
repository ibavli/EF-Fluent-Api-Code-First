using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EfFluentApiCodeFirst.Models.OneToMany
{
    public class Lessons
    {
        public int Id { get; set; }

        public string LessonName { get; set; }

        public int TeacherId { get; set; }

        public Teacher Teacher { get; set; }
    }
}