﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EfFluentApiCodeFirst.Models.OneToOneOrZero
{
    public class StudentAddress
    {
        [Key]
        [ForeignKey("Student")]
        public int StudentAddressId { get; set; }

        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public virtual Student Student { get; set; }
    }
}