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
        public int RangeFrom { get; set; }
        public int RangeTo { get; set; }
        public int Step { get; set; }
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }
    }
}