using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EfFluentApiCodeFirst.Models.ManyToMany
{
    public class Book
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int NumberOfPages { get; set; }

        public ICollection<AuthorsBooksMapping> AuthorsBooksMapping { get; set; }
    }
}