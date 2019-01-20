using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EfFluentApiCodeFirst.Models.ManyToMany
{
    public class AuthorsBooksMapping
    {
        public int BookId { get; set; }
        public virtual Book Book { get; set; }

        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
    }
}