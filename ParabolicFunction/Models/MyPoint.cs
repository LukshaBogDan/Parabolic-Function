using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ParabolicFunction.Models
{
    public class MyPoint
    {
        [Key]
        public int PointId { get; set; }
        public int ChartId { get; set; }
        public int PointX { get; set; }
        public int PointY { get; set; }
    }
}