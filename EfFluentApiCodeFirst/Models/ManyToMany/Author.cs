using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EfFluentApiCodeFirst.Models.ManyToMany
{
    public class Author
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public ICollection<AuthorsBooksMapping> AuthorsBooksMapping { get; set; }
    }
}