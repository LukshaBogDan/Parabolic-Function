using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace ParabolicFunction.Models
{
    public class UserData
    {
        [Key]
        public int UserDataId { get; set; }
        public double RangeFrom { get; set; }
        public double RangeTo { get; set; }
        public double Step { get; set; }
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
    }
}