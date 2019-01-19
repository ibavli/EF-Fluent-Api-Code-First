using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EfFluentApiCodeFirst.Models.OneToOneOrZero
{
    public class Student
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public string StudentSurname { get; set; }

        public virtual StudentAddress StudentAddress { get; set; }
    }
}