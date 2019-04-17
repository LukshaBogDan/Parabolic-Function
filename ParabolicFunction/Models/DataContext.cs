using System;
using System.Collections.Generic;
using System.Web;
using System.Data.Entity;

namespace ParabolicFunction.Models
{
    public class DataContext : DbContext
    {
        
        public DbSet<UserData> UserData { get; set; }
        public DbSet<MyPoint> MyPoint { get; set; }
    }
}